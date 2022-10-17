using project;
using System;

Random rand = new Random();

Coordinates x_coorier = new Coordinates();
Coordinates y_coorier = new Coordinates();

Coordinates x_sctr = new Coordinates();
Coordinates y_sctr = new Coordinates();

Coordinates x_order1 = new Coordinates();
Coordinates y_order1 = new Coordinates();

Coordinates client_x = new Coordinates();
Coordinates client_y = new Coordinates();

x_coorier.x = rand.Next(20);
y_coorier.y = rand.Next(20);
x_sctr.x = rand.Next(20);
y_sctr.y = rand.Next(20);
x_order1.x = rand.Next(20);
y_order1.y = rand.Next(20);
client_x.x = rand.Next(20);
client_y.y = rand.Next(20);
Couriers_1 foot_courier = new Couriers_1();
Couriers_2 sctr_courier = new Couriers_2();

Client client = new Client();

Console.WriteLine($"Координаты клиента: X = {client_x.x} | Y = {client_y.y}");

Console.WriteLine("Координаты пешего курьера:");
Console.WriteLine($"x = {x_coorier.x}");
Console.WriteLine($"y = {y_coorier.y}");

Console.WriteLine("Координаты курьера на самокате:");
Console.WriteLine($"x = {x_sctr.x}");
Console.WriteLine($"y = {y_sctr.y}");

Orders ez_crg = new Orders();
ez_crg.weight = 14;


Console.WriteLine("Координаты лёгкого груза:");
Console.WriteLine($"x = {x_order1.x}");
Console.WriteLine($"y = {y_order1.y}");

Console.WriteLine("Пеший курьер соглашается на данный заказ или отказывается?");
foot_courier.opinion = Console.ReadLine();
Console.WriteLine("Курьер на самокате соглашается на данный заказ или отказывается?");
sctr_courier.opinion = Console.ReadLine();

double s_crr = Math.Pow(MathF.Abs(x_coorier.x - x_order1.x) + MathF.Abs(y_coorier.y - y_order1.y), 0.5) + Math.Pow(MathF.Abs(x_order1.x - client_x.x) + MathF.Abs(y_order1.y - client_y.y),0.5);
double s_sctr = Math.Pow(MathF.Abs(x_sctr.x - x_order1.x) + MathF.Abs(y_sctr.y - y_order1.y), 0.5) + Math.Pow(MathF.Abs(x_order1.x - client_x.x) + MathF.Abs(y_order1.y - client_y.y), 0.5); ;

double time_crr = s_crr / foot_courier.speed;
double time_sctr = s_sctr / sctr_courier.speed;
double sctr_price = sctr_courier.price * s_sctr;
double crr_price = foot_courier.price * s_crr;

sctr_price = -Math.Floor(-sctr_price);
crr_price = -Math.Floor(-crr_price);

if (foot_courier.opinion == "Отказ" || foot_courier.opinion == "отказ")
{   
    Console.WriteLine($"Расстояние до груза курьеру на самокате = {s_sctr}");
    Console.WriteLine($"Время ожидание вашего заказа от курьера на самокате = {time_sctr}");
    Console.WriteLine($"Стоимость доставки = {sctr_price}");
}
else if (sctr_courier.opinion == "Отказ" || sctr_courier.opinion == "отказ")
{
    Console.WriteLine($"Расстояние до груза пешему курьеру = {s_crr}");
    Console.WriteLine($"Время ожидание вашего заказа от пешего курьера = {time_crr}");
    Console.WriteLine($"Стоимость доставки = {crr_price}");
}
else
{
    if (s_crr < s_sctr)
    { 
        Console.WriteLine($"Расстояние до груза пешему курьеру = {s_crr}");
        Console.WriteLine($"Время ожидание вашего заказа от пешего курьера = {time_crr}");
        Console.WriteLine($"Стоимость доставки = {crr_price}");
    }
    else
    {   
        Console.WriteLine($"Расстояние до груза курьеру на самокате = {s_sctr}");
        Console.WriteLine($"Время ожидание вашего заказа от курьера на самокате = {time_sctr}");
        Console.WriteLine($"Стоимость доставки = {sctr_price}");
    }
}