Câu 1: Trình bày sự khác nhau giữa Value Types (Kiểu giá trị) và Reference Typesc(Kiểu tham chiếu) trong C# về cơ chế lưu trữ vùng nhớ (Stack vs Heap).

<br>
1. Vị trí lưu trữ vùng nhớ (Stack vs Heap)

- Value Types (Kiểu giá trị): Lưu trữ trực tiếp dữ liệu trên vùng nhớ Stack đối với biến cục bộ. tuy nhiên nếu là trường/thuộc tính bên trong một class, nó sẽ nằm trên Heap cùng với đối tượng chứa nó.
- Reference Types (Kiểu tham chiếu): Dữ liệu đối tượng thực tế được lưu trên Heap. Biến tham chiếu chỉ lưu địa chỉ bộ nhớ hay con trỏ trỏ tới ô nhớ đó, và địa chỉ này được lưu trên Stack.

<br>
2. Cơ chế gán dữ liệu (Assignment):

- Value Types: Sao chép theo giá trị. Khi thực hiện b = a, hệ thống tạo một bản sao độc lập hoàn toàn. Thay đổi giá trị của b không làm ảnh hưởng đến a.
- Reference Types: Sao chép theo tham chiếu. Khi thực hiện b = a, chỉ có địa chỉ bộ nhớ được sao chép. Cả a và b đều cùng trỏ tới một đối tượng trên Heap. Thay đổi thuộc tính qua b sẽ làm thay đổi a.

<br>
3. Cơ chế quản lý và thu hồi bộ nhớ

- Value Types: Tự động hủy và giải phóng khỏi Stack ngay lập tức khi biến đi ra khỏi phạm vi sử dụng.
- Reference Types: Do bộ dọn rác Garbage Collector quản lý tự động trên Heap. Khi không còn biến nào trên Stack trỏ tới đối tượng trên Heap, GC sẽ thu hồi vùng nhớ này ở đợt quét tiếp theo.

<br>
4. Khả năng nhận giá trị null

- Value Types: Mặc định không thể nhận giá trị null trừ khi khai báo dưới dạng Nullable Type như "int?" hoặc "Nullable<int>".

- Reference Types: Mặc định có thể nhận giá trị null khi biến chưa trỏ đến bất kỳ đối tượng nào trên Heap.

<br>
5. Các kiểu dữ liệu đại diện

- Value Types: int, float, double, bool, char, struct, enum.
- Reference Types: class, interface, delegate, string, object, các loại mảng (array).

<br>
Câu 2: Tính năng Init-only Properties (init) trong C# 9/10 khác gì so với thuộc tính có set thông thường? Nêu trường hợp sử dụng thực tế.

Init-only property là thuộc tính sử dụng từ khóa `init` thay cho `set`. Thuộc tính này chỉ được gán giá trị trong quá trình khởi tạo đối tượng, chẳng hạn khi dùng object initializer hoặc trong constructor. Sau khi đối tượng được khởi tạo, thuộc tính không thể được gán lại. Ngược lại, thuộc tính có `set` thông thường có thể được thay đổi bất cứ lúc nào khi chương trình đang chạy.

Ví dụ:

```csharp
public class User
{
	public string Name { get; init; }
	public int Age { get; set; }
}

var user = new User { Name = "An", Age = 20 };
user.Age = 21;          // Hợp lệ
// user.Name = "Bình";  // Lỗi: Name không thể gán lại sau khi khởi tạo
```

Trong ví dụ trên, `Name` chỉ được gán khi khởi tạo `user`, nên câu lệnh `user.Name = "Bình"` sau đó không hợp lệ. `Age` dùng `set` nên có thể thay đổi từ 20 thành 21.

Trong thực tế, nên dùng `init` cho dữ liệu cần giữ cố định sau khi tạo đối tượng, chẳng hạn thông tin cấu hình, DTO hoặc dữ liệu của một yêu cầu. Nhờ đó, ta vẫn khởi tạo đối tượng thuận tiện bằng object initializer nhưng hạn chế việc thay đổi dữ liệu ngoài ý muốn. Tính năng `init` được giới thiệu trong C# 9 và tiếp tục được hỗ trợ trong C# 10.


<br>
Câu 3: Phân biệt sự khác nhau giữa phương thức virtual ở lớp cha và phương
thức override ở lớp con khi triển khai tính Đa hình (Polymorphism).

<br>
Trong C#, để thực hiện tính đa hình (Polymorphism), lớp cha thường khai báo phương thức bằng từ khóa virtual, còn lớp con viết lại bằng từ khóa override.

1. Phương thức `virtual` ở lớp cha:
- Được khai báo trong lớp cha với từ khóa `virtual`.
- Là phiên bản cơ sở, định nghĩa hành vi mặc định của phương thức.
- Cho phép lớp con có quyền ghi đè lại hành vi đó.
- Dùng khi muốn lớp cha cung cấp giao diện hoặc logic chung, nhưng để lớp con tùy biến theo nhu cầu.

2. Phương thức `override` ở lớp con:
- Được khai báo trong lớp con với từ khóa `override`.
- Phải ghi đè đúng một phương thức `virtual` hoặc `abstract` của lớp cha.
- Có cùng tên, cùng danh sách tham số và kiểu trả về với phương thức gốc.
- Thay đổi logic thực thi của phương thức theo từng đối tượng cụ thể.

3. Sự khác nhau cơ bản:
- Về vị trí khai báo: `virtual` nằm ở lớp cha, `override` nằm ở lớp con.
- Về mục đích: `virtual` định nghĩa khả năng thay đổi hành vi; `override` thực hiện việc thay đổi đó.
- Về thời điểm thực thi: khi gọi qua biến kiểu lớp cha, C# sẽ thực hiện phương thức phù hợp với kiểu đối tượng thực tế (runtime polymorphism).
- Nếu không có `virtual`/`override`, phương thức được gọi theo kiểu khai báo của biến, không thể hiện đa hình đúng nghĩa.

4. Ví dụ minh họa
```csharp
public class chó
{
    public virtual void Speak()
    {
        Console.WriteLine("chó speaks");
    }
}

public class Minh : chó
{
    public override void Speak()
    {
        Console.WriteLine("Minh barks");
    }
}

chó a = new Minh();
a.Speak();   // Kết quả: Minh barks
```

Ở đây, `chó.Speak()` là phương thức `virtual`; `Minh.Speak()` là phương thức `override`.
Khi chương trình chạy, hệ thống sẽ gọi phiên bản `Speak()` của đối tượng thực tế là `Minh`, chứ không phải phiên bản của kiểu biến `chó`.

=>`virtual` là “cho phép ghi đè”, `override` là “ghi đè lại hành vi đã định nghĩa”. Và Cặp `virtual` + `override` là cơ chế nền tảng để C# triển khai tính đa hình ở runtime, giúp chương trình linh hoạt, dễ mở rộng và dễ bảo trì.

<br>
Câu 4: Tại sao một thành phần được khai báo là static trong Lớp (Class) lại không thể truy xuất thông qua một thể hiện (Object Instance) được tạo bằng toán tử new?

Vì `static` trong C# không thuộc về đối tượng cụ thể nào, mà thuộc về cả class. Nói cách khác, nó là dữ liệu hoặc phương thức của kiểu, chứ không phải của từng instance được tạo ra bằng `new`. Do đó, khi ta khai báo một biến, phương thức, thuộc tính hay trường là `static`, thì chỉ có một bản duy nhất cho toàn bộ class, không phải một bản riêng cho mỗi đối tượng.

Ví dụ:

```csharp
public class SinhVien
{
    public static int SoLuong = 0;

    public SinhVien()
    {
        SoLuong++;
    }
}
```

Ở đây, `SoLuong` không phải là dữ liệu riêng của mỗi `SinhVien`, mà là dữ liệu chung của cả class. Mỗi lần có một đối tượng mới được tạo, biến này lại tăng lên một đơn vị, và tất cả các đối tượng đều nhìn thấy cùng một giá trị. Tức là nó không thuộc về object nào cả.

Vì thế, đoạn code dưới đây là sai:

```csharp
SinhVien sv = new SinhVien();
Console.WriteLine(sv.SoLuong);   // Sai
```

Phải truy cập theo cách này:

```csharp
Console.WriteLine(SinhVien.SoLuong);   // Đúng
```

Lý do C# không cho phép truy cập `static` qua instance là vì `static` không gắn với một đối tượng cụ thể nào. Nếu cho phép, sẽ rất dễ gây nhầm lẫn: người ta sẽ nghĩ thành phần đó là dữ liệu riêng của từng object, nhưng thực chất nó là dữ liệu của class. Điều này làm code khó hiểu và không rõ ràng khi thiết kế.

Về mặt kỹ thuật, các thành phần `static` được lưu ở mức class, không nằm trong bộ nhớ cá nhân của mỗi object. Chính vì vậy, chúng tồn tại ngay cả khi chưa có đối tượng nào được tạo ra, và chỉ nên được truy cập thông qua tên class hoặc bên trong chính class đó.

Kết luận: `static` là thành phần của lớp, không phải của đối tượng, nên không thể truy xuất qua đối tượng được tạo bằng `new`; phải dùng tên class để truy cập.

<br>