using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;

namespace CHECK_HOTMAIL_LINKED_FACEBOOK
{
    public partial class Form1 : Form
    {
        private List<string> emails = new List<string>();
        private bool isChecking = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            if (!isChecking)
            {
                isChecking = true;
                isStopping = false; // Đảm bảo rằng biến isStopping được thiết lập lại khi bắt đầu một quá trình kiểm tra mới
                var chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = true;

                // Khởi tạo trình duyệt Chrome
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("--window-size=1,1");
                IWebDriver driver = new ChromeDriver(chromeDriverService, options);

                // Mở trang đăng nhập Facebook
                driver.Navigate().GoToUrl("https://mbasic.facebook.com/login/identify/?ctx=recover&c=https%3A%2F%2Fmbasic.facebook.com%2F&multiple_results=0&ars=facebook_login&from_login_screen=0&lwv=100&_rdr");

                // Tạo một Thread mới để thực hiện kiểm tra email
                Thread checkThread = new Thread(() =>
                {
                    int totalCount = emails.Count;
                    int currentCount = 0;

                    foreach (string email in emails)
                    {
                        // Kiểm tra biến isStopping để xem liệu quá trình kiểm tra có nên dừng lại không
                        if (isStopping)
                        {
                            // Đóng trình duyệt và kết thúc tiến trình
                            driver.Quit();
                            isChecking = false;
                            return;
                        }

                        // Tính toán tiến trình
                        currentCount++;
                        int progress = (int)(((double)currentCount / totalCount) * 100);

                        // Cập nhật ProgressBar thông qua Invoke
                        UpdateProgressBar(progress);

                        // Các thao tác kiểm tra email ở đây...
                        bool isTrue = IsEmailFound(driver, email);

                        // Hiển thị kết quả
                        string resultText = $"{email} --> {(isTrue ? "True" : "False")}";
                        AddResultToRichTextBox(resultText, isTrue ? Color.Green : Color.Red);
                    }

                    // Đóng trình duyệt
                    driver.Quit();

                    // Đánh dấu đã kết thúc kiểm tra
                    isChecking = false;
                });

                // Khởi động Thread
                checkThread.Start();
            }
            else
            {
                MessageBox.Show("Đang kiểm tra, vui lòng đợi...");
            }
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn tệp
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Đọc nội dung của tệp đã chọn và thêm vào danh sách emails
                string filePath = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(filePath);
                emails.AddRange(lines);
            }
        }

        private string ExtractEmail(string input)
        {
            // Tách chuỗi theo dấu hai chấm
            string[] parts = input.Split(':');

            // Trả về phần tử đầu tiên là phần email
            return parts[0];
        }
        private List<string> successfulEmails = new List<string>();
        private bool IsEmailFound(IWebDriver driver, string emailAndPassword)
        {
            // Tách phần email từ chuỗi emailAndPassword
            string email = ExtractEmail(emailAndPassword);

            // Tiếp tục xử lý kiểm tra email như trước
            try
            {
                // Tìm ô nhập email và điền thông tin
                IWebElement emailInput = driver.FindElement(By.XPath("//*[@id=\"identify_search_text_input\"]"));
                emailInput.Clear(); // Xóa dữ liệu trước khi điền mới
                emailInput.SendKeys(email.Trim());

                // Tìm và ấn nút đăng nhập
                IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"did_submit\"]"));
                loginButton.Click();

                // Chờ cho trang load và xử lý kết quả
                System.Threading.Thread.Sleep(3000); // Thời gian chờ để trang load

                // Kiểm tra nếu có thông báo email không khớp hoặc không tìm thấy tài khoản
                driver.FindElement(By.XPath("//div[contains(text(),'doesn’t match any account')]"));
                return false;
            }
            catch (NoSuchElementException)
            {
                try
                {
                    // Kiểm tra nếu có thông báo mật khẩu không đúng
                    driver.FindElement(By.XPath("//div[contains(text(),'Your search did not return any results. Please try again with other information.')]"));
                    return false;
                }
                catch (NoSuchElementException)
                {
                    // Nếu không có thông báo lỗi nào xuất hiện, email được tìm thấy
                    // Thêm email thành công vào danh sách
                    successfulEmails.Add(email);

                    // Điều hướng tới URL cụ thể
                    driver.Navigate().GoToUrl("https://mbasic.facebook.com/login/identify/?ctx=recover&c=https%3A%2F%2Fmbasic.facebook.com%2F&multiple_results=0&ars=facebook_login&from_login_screen=0&lwv=100&_rdr");

                    // Tiếp tục quá trình kiểm tra
                    // Thêm các bước kiểm tra tiếp theo nếu cần

                    return true;
                }
            }
        }

        // Phương thức để lưu danh sách các email kiểm tra thành công vào tệp tin văn bản
        private bool SaveSuccessfulEmailsToFile(string filePath)
        {
            try
            {
                // Ghi danh sách email thành công vào tệp tin
                File.WriteAllLines(filePath, successfulEmails);
                return true; // Trả về true nếu lưu thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu file: {ex.Message}");
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }



        private void AddResultToRichTextBox(string text, Color color)
        {
            try { 
            if (txtResult.InvokeRequired)
            {
                // Nếu không phải từ luồng UI chính, gọi Invoke để thực hiện
                txtResult.Invoke(new Action(() => AddResultToRichTextBox(text, color)));
            }
            else
            {
                // Thêm kết quả vào RichTextBox và chỉnh màu sắc
                txtResult.SelectionStart = txtResult.TextLength;
                txtResult.SelectionLength = 0;
                txtResult.SelectionColor = color;
                txtResult.AppendText(text + Environment.NewLine);
                txtResult.SelectionStart = txtResult.TextLength;
                txtResult.SelectionLength = 0;
                txtResult.SelectionColor = txtResult.ForeColor; // Reset màu sắc
            }
            }catch (Exception ex) { }

        }
        private void UpdateProgressBar(int progress)
        {
            if (progressBar1.InvokeRequired)
            {
                // Nếu không phải từ luồng UI chính, gọi Invoke để thực hiện
                progressBar1.Invoke(new Action(() => UpdateProgressBar(progress)));
            }
            else
            {
                // Cập nhật giá trị của ProgressBar
                progressBar1.Value = progress;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSaveListTrue_Click(object sender, EventArgs e)
        {
            // Đường dẫn tới tệp tin để lưu danh sách email thành công
            string filePath = "successful_emails.txt";

            // Thực hiện lưu danh sách email thành công vào tệp tin và kiểm tra kết quả
            if (SaveSuccessfulEmailsToFile(filePath))
            {
                MessageBox.Show("Lưu file thành công");
            }
            else
            {
                MessageBox.Show("Lưu file không thành công");
            }
        }

        private bool isStopping = false;
        private void btnStopp_Click(object sender, EventArgs e)
        {
            isStopping = true;
        }
    }
}
