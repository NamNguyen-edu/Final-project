MÔN PHÁT TRIỂN ỨNG DỤNG DESKTOP
Tên đề tài : Phát triển ứng dụng quản lý khách sạn
Trong bối cảnh phát triển mạnh mẽ của khoa học – công nghệ, công nghệ thông tin đã trở thành nền tảng quan trọng thúc đẩy quá trình hiện đại hóa và tối ưu hóa hoạt động quản trị trong nhiều lĩnh vực. Việc ứng dụng hệ thống thông tin vào quản lý không chỉ góp phần tự động hóa quy trình nghiệp vụ, mà còn đảm bảo tính chính xác, toàn vẹn và khả năng truy xuất dữ liệu một cách hiệu quả. Bên cạnh đó, các giải pháp công nghệ cho phép rút ngắn thời gian xử lý, hỗ trợ phân tích và đưa ra báo cáo thống kê nhanh chóng, tạo cơ sở cho việc ra quyết định kịp thời. Do vậy, phát triển phần mềm quản lý chuyên biệt được xem là hướng tiếp cận tất yếu nhằm nâng cao hiệu quả tổ chức, giảm thiểu sai sót thủ công và tăng cường khả năng đáp ứng trước yêu cầu thực tiễn.
Mô tả và mục tiêu dự án
Mô Tả:
Hệ thống quản lý khách sạn mà nhóm sử dụng được tham khảo từ nguồn mã trên Github, xây dựng bằng C# WinForms và tổ chức theo mô hình phân tầng gồm GUI, BUS, DAO và DTO. Phần mềm cung cấp đầy đủ các chức năng quản lý cốt lõi như phòng, loại phòng, đặt phòng, khách hàng, nhân viên, dịch vụ, tiện nghi, tài khoản và hóa đơn, đồng thời hỗ trợ thống kê và xuất dữ liệu. Giao diện tương đối trực quan, dễ thao tác, là nền tảng thích hợp để nhóm kế thừa, mở rộng và hoàn thiện trong quá trình thực hiện đề tài.


**MỤC TIÊU:**
Phát triển hệ thống quản lý khách sạn nhằm hỗ trợ tối ưu các hoạt động như đặt phòng, theo dõi thông tin khách lưu trú, quản lý dịch vụ và giá phòng. Hệ thống hướng tới việc rút ngắn thời gian xử lý nghiệp vụ, giảm sai sót trong quản lý, đồng thời cung cấp dữ liệu rõ ràng và chính xác để người dùng dễ dàng tra cứu và sử dụng.
**Thành viên:**
Nguyễn Duy Bảo
Lý Hồ Hiếu Hạnh
Nguyễn Hoàng Nhật Nam
Lê Doãn Phú

**Kiến thức áp dụng**
Ngôn ngữ lập trình C# và WinForms
Sử dụng C# để xây dựng giao diện người dùng, xử lý sự kiện và triển khai các chức năng nghiệp vụ.
WinForms được áp dụng để thiết kế form, control tương tác, hiển thị danh sách phòng, khách hàng và hóa đơn.
Kết hợp custom control và xử lý UI nhằm cải thiện trải nghiệm người dùng so với control mặc định.
Kiến trúc phần mềm nhiều lớp (GUI – BUS – DAO – DTO)
GUI (Presentation Layer): xử lý giao diện, tiếp nhận thao tác người dùng.
BUS (Business Layer): xử lý logic nghiệp vụ, kiểm tra điều kiện, gọi dữ liệu từ DAO.
DAO (Data Access Layer): kết nối SQL Server, thực hiện truy vấn CRUD (Insert, Update, Delete, Select).
DTO (Data Transfer Object): giữ vai trò mô hình dữ liệu, giúp truyền dữ liệu giữa các tầng rõ ràng và tránh lệ thuộc trực tiếp vào database.
Cơ sở dữ liệu với SQL Server
Thiết kế bảng dữ liệu quản lý phòng, khách hàng, dịch vụ, hóa đơn, tài khoản người dùng,...
Sử dụng T-SQL để xây dựng câu lệnh truy vấn, stored procedure cho các thao tác nghiệp vụ.
Quản lý khóa chính – khóa ngoại, ràng buộc toàn vẹn dữ liệu để tránh lỗi phát sinh khi vận hành.
Kiểm thử và xử lý lỗi
Kiểm tra chức năng khi thêm – xoá – sửa dữ liệu, tính phí phòng, in hóa đơn,...
Xử lý ngoại lệ (exception), kiểm tra tính hợp lệ đầu vào để tránh lỗi runtime.
Theo dõi log và cải thiện hiệu năng truy vấn ở các chức năng nhiều dữ liệu.
Công nghệ sử dụng
Dự án được phát triển trên nền tảng C# thuộc môi trường .NET Framework/.NET Core, sử dụng Windows Forms (WinForms) để xây dựng giao diện ứng dụng Desktop. Hệ thống lưu trữ và quản lý dữ liệu thông qua Microsoft SQL Server, đồng thời tích hợp Entity Framework Core làm ORM nhằm hỗ trợ thao tác với cơ sở dữ liệu linh hoạt và tối ưu hơn.
Các thư viện bổ trợ cũng được sử dụng để nâng cao trải nghiệm và khả năng mở rộng của phần mềm, gồm:
LiveCharts – hiển thị biểu đồ, thống kê trực quan.
MiniExcel – hỗ trợ xuất báo cáo nhanh dưới dạng Excel.
System.Media.SoundPlayer – thêm hiệu ứng âm thanh cho thao tác người dùng.
Quá trình thiết kế và phát triển giao diện được thực hiện bằng Figma cho phần prototype và Visual Studio cho quá trình lập trình, biên dịch và triển khai dự án.


**Tài Liệu Thiết Kế**
XEM TẠI ĐÂY
**Tài liệu cho người dùng cuối**
https://docs.google.com/document/d/1-CXPADXYelVAHcclm1upGS8X6H1JOe6d/edit?usp=drive_link&ouid=106608410238280657212&rtpof=true&sd=true

**Lời cảm ơn**
Chúng em xin gửi lời cảm ơn chân thành đến thầy Nguyễn Mạnh Tuấn, người đã dành thời gian hướng dẫn, hỗ trợ và định hướng cho chúng em trong quá trình thực hiện đề tài. Sự tận tâm, nhiệt tình và những ý kiến đóng góp quý báu của thầy đã giúp chúng em tích lũy thêm nhiều kiến thức và kinh nghiệm thực tiễn để hoàn thiện bài báo cáo một cách tốt nhất. Chúng em rất trân trọng sự đồng hành của thầy trong suốt thời gian triển khai đồ án này.

