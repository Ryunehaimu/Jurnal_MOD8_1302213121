// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using System.Net.Http.Headers;

BankTranferConfig config = new BankTranferConfig();
Console.WriteLine("Pilih Bahasa(en/id)");
config.bank.lang = Console.ReadLine();
if (config.bank.lang == "en")
{
    Console.Write("Please insert the amount of money to transfer: ");
    String transfer = Console.ReadLine();
    int nominal = Convert.ToInt32(transfer);
    if (transfer <= config.bank.transfer.threshold)
    {
        int totaltranfer = nominal + config.bank.transfer.low_fee;
        Console.WriteLine("Transfer fee: " + config.bank.transfer.low_fee);
        Console.WriteLine("Total amount : " + totaltranfer);
    }
    else
    {
        int totaltranfer = nominal + config.bank.transfer.high_fee;
        Console.WriteLine("Transfer fee: " + config.bank.transfer.high_fee);
        Console.WriteLine("Total amount : " + totaltranfer);
    }

    Console.WriteLine("Select tranfer method:");
    Console.WriteLine("1. RTO(real-time)");Console.WriteLine("2. SKN");Console.WriteLine("3. RTGS");Console.WriteLine("4. BI FAST");
    String methods = Console.ReadLine();
    config.bank.methods[0] = methods;
}
else
{
    Console.Write("Masukan jumlah uang yang akan di-transfer: ");
    String transfer = Console.ReadLine();
    int nominal = Convert.ToInt32(transfer);
    if (transfer <= config.bank.transfer.threshold)
    {
        int totaltranfer = nominal + config.bank.transfer.low_fee;
        Console.WriteLine("Biaya transfer: " + config.bank.transfer.low_fee);
        Console.WriteLine("Total biaya: "+totaltranfer);
    }
    else
    {
        int totaltranfer = nominal + config.bank.transfer.high_fee;
        Console.WriteLine("Biaya transfer: " + config.bank.transfer.high_fee);
        Console.WriteLine("Total biaya: " + totaltranfer);
    }
    Console.WriteLine("Pilih metode tranfer:");
    Console.WriteLine("1. RTO(real-time)"); Console.WriteLine("2. SKN"); Console.WriteLine("3. RTGS"); Console.WriteLine("4. BI FAST");
    String methods = Console.ReadLine();
    config.bank.methods[0] = methods;
}