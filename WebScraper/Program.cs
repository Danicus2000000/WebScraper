using System.Net;
while (true)
{
    string result = "";
    #region Request
    using (HttpClient getData = new())
    {
        bool pass = true;
        while (pass)
        {
            try
            {
                Console.WriteLine("Please enter a web address to scrape:");
                string address = "";
                address = Console.ReadLine() ?? "";
                result = getData.GetAsync(address).Result.Content.ReadAsStringAsync().Result;
                pass = false;
            }
            catch (Exception)
            {
                Console.WriteLine("The URL provided was invalid!");
                pass = true;
            }
        }
        result = result.Replace(">", ">\n");
        Console.WriteLine(result);
    }
    #endregion
    #region Save
    char key;
    while (true) 
    {
        Console.WriteLine("Would you like to save the data to a file? (Y/N)");
        key=Console.ReadKey().KeyChar;
        Console.WriteLine();
        if(key=='y' || key == 'n') 
        {
            break;
        }
    }
    if (key == 'y') 
    {
        string filename;
        Console.WriteLine("Please enter the filename: ");
        filename = Console.ReadLine() ?? "";
        StreamWriter write=File.CreateText(filename+".txt");
        write.Write(result);
        write.Close();
        Console.WriteLine("File Saved!");
    }
    #endregion
    #region again
    char restartKey;
    while (true) 
    {
        Console.WriteLine("Would you like to scrape another page? (Y/N)");
        restartKey=Console.ReadKey().KeyChar;
        Console.WriteLine();
        if (restartKey=='y' || restartKey == 'n')
        {
            break;
        }
    }
    if (restartKey == 'n') 
    {
        break;
    }
    #endregion
    Console.Clear();
}