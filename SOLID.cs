class SOLID
{

    //
    // new order
    // order.CreateOrder()
    // Facade Pattern
    // tạo ra cổng_chun_mua(){
    // order
    //  payment  tồn kho. shipping
    //}
    // cổng_chun_mua.order
    // cổng_chun_mua.payment
}

/// /
// order -  xử lý đơn hàng
// payment
// tồn kho
// giao hàng
// thông báo
// tích điểm

//
public class OrderSer
{
    public void CreateOrder() { }
}

public class PaymentSer { }

public class UpdateInventorSẻ { }

public class ShippingSer { }

public class NotiSer { }

public class PointSer { }

// S:
interface IGuiThongBao
{
    // gửi mail
    void Gui();
    //gửi zalo
}

// O:
/*
    Đóng: đóng code cũ / class / function đã dùng, module đã deploy. Hạn chế thay đổi trực tiếp khi có yêu cầu mới
    
    Mở: kế thừa , implement , override để mình mở rộng thêm
*/

//L : Nguyên tắc thay thế Liskov -  Điều này có nghĩa là khi một lớp con kế thừa từ một lớp cha, nó phải duy trì được các hành vi và chức năng của lớp cha.

abstract class Bird
{
    public string Ten { get; set; }
}

interface IFly
{
    public void Fly();
}

//chim se
class ChimSe : Bird, IFly
{
    public void Fly()
    {
        Console.WriteLine("ChimSe bay cao");
    }
}

class ChimCachCut : Bird
{
    // public override void Fly()
    // {
    //     throw new NotImplementedException();
    // }
}

// I: => hướng về tách interface
// phân tách interface thành nhiều caí hơn , không đồn quá nhiều method vào trong 1 interface
// 1 class không nên bị hụ thuộc vào những interface mà nó không dùng đên => giảm sự phụ thuộc ,

interface IPrinter
{
    void Photo();

    void Scan();

    void PhotoColor();
}

public class MayIn1990 : IPrinter
{
    public void Photo()
    {
        Console.WriteLine("Photo copy");
    }

    public void PhotoColor()
    {
        // máy cũ kh photo màu dc
        throw new NotImplementedException();
    }

    public void Scan()
    {
        // mấy cùid bắp kh scan được
        throw new NotImplementedException();
    }
}

public class MayIn2010 : IPrinter
{
    public void Photo()
    {
        Console.WriteLine("Photo copy");
    }

    public void PhotoColor()
    {
        Console.WriteLine("Photo màu");
    }

    public void Scan()
    {
        // mấy cùid bắp kh scan được
        throw new NotImplementedException();
    }
}

// -----------------------------------------

// D : Dependency Inversion Principle (DIP) - Nguyên tắc đảo ngược phụ thuộc
// các module cấp cao không nên phụ thuộc trực tiêos vào module cấp thấp

// cấp cao sẽ là phần điều phối , xử lý logic tôngt rheer
// cấp thấp : thực thi cụ thể
// Lợi ích : dễ dàng mở rộng : muốn thêm loại mới chỉ cần implement interface , không cần sửa code cũ
// dễ test, giảm phụ thuộc vào , dể bảo trù ,
//

// => interface , abstract class

// Design princuples (ex: SOLID,...):  chỉ la nguyên tắc , chỉ dẫn cách thiết kế
// Design pattern: mẫu thiết kế, giải pháp cụ thể, được công nhận và ứng dụng vào các vấn đề phổ biến trong thiết kế phần mềm

//SOLID: nguyên tắc thiết kế - khong phải design pattent
// design pattern : áp dụng các nguyên tắc vào giải quyết tình huống cụ thể
// DIP và DI 
//DIP là nguyên lý, nguyên tắc
//DI cách thực thi nguyên tắc 
// => interface , abstract class
class SaveDataService
{
    public SaveDataService(string text) { }

    // save
    public void SaveData(List<Student> students)
    {
        // lưu json
        Console.WriteLine("Luu json thanh cong");
    }
}

class QLHocVien // class cap cao
{
    public List<Student> lst = new List<Student>();
    public SaveDataService _saveDataService;

    // ap dung DIP
    public QLHocVien(SaveDataService saveDataService)
    {
        _saveDataService = saveDataService;
    }

    // luu
    // SaveDataService ser = new SaveDataService(); // service khacs
    // ham goi chuc nang luu
    public void LuuThongTin()
    {
        _saveDataService.SaveData(lst);
    }
}
