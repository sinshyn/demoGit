using System.Reflection;

class SimpleContainer
{
    // DI - dependency injection
    // thực hiện tính chất của DIP
    // ds service cần đăng ký

    // Ipayment -> momo
    // Isave data -> saveJson
    // key: interface
    // value: implement interfce tương ứng thực thi interface
    Dictionary<Type, Type> registers = new Dictionary<Type, Type>();

    //hàm đăng kí
    public void Registers<TService, TImplement>()
    {
        // registers.Add(typeof(TService), typeof(TImplement));
        registers[typeof(TService)] = typeof(TImplement);
    }

    public TService KhoiTao<TService>()
    {
        return (TService)KhoiTao(typeof(TService));
    }

    // hàm khởi tạo không cần new => activator
    public object KhoiTao(Type serviceType)
    {
        if (registers.ContainsKey(serviceType))
        {
            Type implementType = registers[serviceType]; // lấy ra các value cần khởi tạo
            // tách hàm  -gọi hàm khởi tạo
            return CreateInstance(implementType);
        }
        return "";
    }

    // hàm khởi tạo
    // giả DI IPayment : Momo
    // momo(), momo(2 param)
    private object CreateInstance(Type type)
    {
        // Lấy constructor đầu tiên (có thể chọn constructor nhiều tham số nhất)
        ConstructorInfo constructor = type.GetConstructors()[0];
        // Lấy danh sách tham số của constructor
        ParameterInfo[] parameters = constructor.GetParameters();

        // Nếu không có tham số, tạo instance luôn
        if (parameters.Length == 0)
        {
            return Activator.CreateInstance(type);
        }

        // Nếu có tham số, tạo instance của từng tham số rồi truyền vào
        object[] parameterInstances = new object[parameters.Length];
        for (int i = 0; i < parameters.Length; i++)
        {
            parameterInstances[i] = KhoiTao(parameters[i].ParameterType);
        }
        return constructor.Invoke(parameterInstances);
    }
}
