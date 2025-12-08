# PHÁT TRIỂN ỨNG DỤNG DESKTOP

## Tên đề tài: Phát triển ứng dụng quản lý khách sạn

Trong bối cảnh phát triển mạnh mẽ của khoa học – công nghệ, công nghệ thông tin đã trở thành nền tảng quan trọng thúc đẩy quá trình hiện đại hóa và tối ưu hoá các quy trình quản lý. Đề tài này tập trung xây dựng một hệ thống quản lý khách sạn hỗ trợ cho chủ khách sạn và nhân viên dễ dàng kiểm soát hoạt động kinh doanh, nâng cao hiệu quả phục vụ khách hàng.

---

## Mô tả và Mục tiêu dự án

### Mô tả
Hệ thống được tham khảo và phát triển dựa trên nguồn mã từ Github, xây dựng bằng ngôn ngữ C# với nền tảng WinForms. Kiến trúc phần mềm tổ chức theo mô hình phân tầng gồm: GUI (Presentation Layer), BUS (Business Layer), DAO (Data Access Layer), và DTO (Data Transfer Object). Điều này đảm bảo sự tách biệt rõ ràng giữa giao diện, xử lý nghiệp vụ, truy cập dữ liệu và các mô hình truyền dữ liệu.

### Mục tiêu
- Hỗ trợ tối ưu hóa các hoạt động như đặt phòng, theo dõi thông tin khách lưu trú, quản lý dịch vụ, và tính giá phòng.
- Tăng cường tính bảo mật, chính xác và minh bạch trong quản lý thông tin khách hàng và hóa đơn.
- Cải thiện quy trình vận hành, nâng cao trải nghiệm người dùng.

---

## Thành viên nhóm
- Nguyễn Duy Bảo
- Lý Hồ Hiếu Hạnh
- Nguyễn Hoàng Nhật Nam
- Lê Doãn Phú

---

## Kiến thức áp dụng

- **Ngôn ngữ lập trình:** C#, WinForms
    - Xây dựng giao diện, xử lý sự kiện, triển khai chức năng nghiệp vụ.
    - Sử dụng WinForms để thiết kế các form, control tương tác, hiển thị danh sách phòng, khách hàng, hóa đơn.
    - Ứng dụng custom control cải thiện trải nghiệm người dùng so với control mặc định.

- **Kiến trúc phần mềm nhiều lớp (GUI – BUS – DAO – DTO):**
    - **GUI (Presentation Layer):** Xử lý giao diện, tiếp nhận thao tác người dùng.
    - **BUS (Business Layer):** Xử lý logic nghiệp vụ, kiểm tra điều kiện, gọi dữ liệu từ DAO.
    - **DAO (Data Access Layer):** Kết nối SQL Server, thực hiện truy vấn CRUD (Insert, Update, Delete, Select).
    - **DTO (Data Transfer Object):** Đóng vai trò mô hình dữ liệu, truyền dữ liệu giữa các tầng, tránh lệ thuộc trực tiếp vào database.

- **Cơ sở dữ liệu với SQL Server:**
    - Thiết kế bảng quản lý phòng, khách hàng, dịch vụ, hóa đơn, tài khoản người dùng,...
    - Sử dụng T-SQL xây dựng câu lệnh truy vấn, stored procedure cho các thao tác nghiệp vụ.
    - Quản lý khóa chính – khóa ngoại, ràng buộc toàn vẹn dữ liệu để tránh lỗi phát sinh.

- **Kiểm thử và xử lý lỗi:**
    - Kiểm tra chức năng thêm, xóa, sửa dữ liệu, tính phí phòng, in hóa đơn,...
    - Xử lý ngoại lệ (exception), kiểm tra tính hợp lệ đầu vào tránh lỗi runtime.
    - Theo dõi log, tối ưu hiệu năng truy vấn với các chức năng có nhiều dữ liệu.

---

## Công nghệ sử dụng

- **Môi trường phát triển:** .NET Framework / .NET Core
- **Giao diện:** Windows Forms (WinForms)
- **Thiết kế giao diện:** Figma (prototype)
- **IDE:** Visual Studio

**Thư viện bổ trợ:**
- LiveCharts: Hiển thị biểu đồ, thống kê trực quan
- MiniExcel: Hỗ trợ xuất báo cáo Excel
- System.Media.SoundPlayer: Thêm hiệu ứng âm thanh thao tác

---

## Tài liệu thiết kế

 [Vui lòng xem tại:](https://www.figma.com/design/Bu9eMyV22omL6QS5m668gA/-Desktop--Hotel-Management?node-id=0-1&t=xDi6yZJ5HBtgXV2B-1)

## Tài liệu hướng dẫn người dùng

- [Tài liệu cho người dùng cuối](https://docs.google.com/document/d/1-CXPADXYelVAHcclm1upGS8X6H1JOe6d/edit?usp=drive_link&ouid=106608410238280657212&rtpof=true&sd=true)

---

## Lời cảm ơn

Nhóm xin gửi lời cảm ơn chân thành tới thầy Nguyễn Mạnh Tuấn, người đã dành thời gian hướng dẫn, hỗ trợ và định hướng cho nhóm trong suốt quá trình thực hiện dự án.
