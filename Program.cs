using ClinicConsoleApp;
List<Doctor> doctorList = new List<Doctor>();
List<string> doctorList2 = new List<string>();
int counter = 0;
int[,] diary = new int[4, 7];
// option menu \\
void ClinicOption()
{
    Console.WriteLine("1 - To add doctor");
    Console.WriteLine("2 - To add Patient");
    Console.WriteLine("3 - To present doctor");
    Console.WriteLine("4 - To present all doctors");
    Console.WriteLine("5 - To present a diary");
    Console.WriteLine("6 - To present a diary lower 5 patients");

}
// create doctor object \\
void CreateNewObject()
{
    Doctor newDoctoer = new Doctor();
    Console.WriteLine("first name");
    newDoctoer.firstName = Console.ReadLine();
    Console.WriteLine("last name");
    newDoctoer.lastName = Console.ReadLine();
    Console.WriteLine("position");
    newDoctoer.position = Console.ReadLine();
    Console.WriteLine("numbers of patients");
    newDoctoer.numbersOfPatients = int.Parse(Console.ReadLine());
    Console.WriteLine("birth year ");
    newDoctoer.birthYear = int.Parse(Console.ReadLine());
    doctorList.Add(newDoctoer);
    AddToFile(newDoctoer);
}
// add to file \\
void AddToFile(Doctor doctorDetails)
{
 
    FileStream fs = new FileStream(@$"C:\Doctor\all-doctors.txt", FileMode.Append);
    using (StreamWriter writer = new StreamWriter(fs))
    {
        writer.Write($",id:{counter} FIRST NAME:{doctorDetails.firstName} LAST NAME:{doctorDetails.lastName}" +
                         $" POSITION:{doctorDetails.position} NUMBERS OF PETIENS:{doctorDetails.numbersOfPatients}" +
                         $" BIRTH YEAR:{doctorDetails.birthYear}\n");
        counter++;
    }                                     
    FileStream fs2 = new FileStream(@$"C:\Doctor\{doctorDetails.firstName}.txt", FileMode.Append);
    using(StreamWriter writer2 = new StreamWriter(fs2))
    {
        
        writer2.Write($",FIRST NAME:{doctorDetails.firstName} LAST NAME:{doctorDetails.lastName}" +
                     $" POSITION:{doctorDetails.position} NUMBERS OF PETIENS:{doctorDetails.numbersOfPatients}" +
                     $" BIRTH YEAR:{doctorDetails.birthYear}\n");
    }
    
}
// present doctor \\
void PresentDoctorByName(string name)
{
    FileStream fs = new FileStream(@$"C:\Doctor\{name}.txt", FileMode.Open);
    using(StreamReader reader = new StreamReader(fs))
    {
        Console.WriteLine(reader.ReadLine());
    }
}
// present all doctors \\
void PresentAllDoctors()
{
    FileStream fs = new FileStream(@"C:\Doctor\all-doctors.txt", FileMode.Open);
    using(StreamReader reader = new StreamReader(fs))
    {
        Console.WriteLine(reader.ReadLine());
    }
}
// add Patient \\
void AddPetientToDoctor()
{
    string newLine;
    FileStream fs = new FileStream(@$"C:\Doctor\{name}.txt", FileMode.Open);
    using (StreamReader reader = new StreamReader(fs))
    {
        string section = reader.ReadLine();
        int indexReader = section.IndexOf("NS");
        string str = section.Substring(indexReader + 3, 2); // catch the num;
        string str2 = section.Substring(0, indexReader + 3); // catch than 0 tiil num
        string str3 = section.Substring(indexReader + 5); //catch than num till end
        int num = int.Parse(str);
        num++;
        newLine = $"{str2}{num}{str3}";
    }
    FileStream fss = new FileStream($@"C:\Doctor\{name}.txt", FileMode.Create);
    using (StreamWriter writer = new StreamWriter(fss))
    {
        writer.WriteLine(newLine);
        Console.WriteLine(newLine);
    }

    FileStream fileStream = new FileStream($@"C:\Doctor\all-doctors.txt", FileMode.Open);
    using (StreamReader reader = new StreamReader(fileStream))
    {
       string firstLine = reader.ReadLine();
       int indexReader = firstLine.IndexOf("NS");
       string catchNum = firstLine.Substring(indexReader + 3, 2); // catch the num;
       string str2 = firstLine.Substring(0, indexReader + 3); // catch than 0 tiil num
       string str3 = firstLine.Substring(indexReader + 5); //catch than num till end
       int conver = int.Parse(catchNum);
       for(int i = 0; i < reader.Peek(); i++)
        {
            string readerNum = reader.ReadLine();
            int changeNumber = readerNum.IndexOf("NS");
            string subNum = readerNum.Substring(changeNumber + 3, 2);
            int conver2 = int.Parse(subNum);
            if (conver > conver2)
            {
            conver = conver2;
            Console.WriteLine($"{str2}{conver}{str3}");
            }
            else
            {
             Console.WriteLine($"{str2}{conver2}{str3}");
            }
        }
    }
    //by list\\ 
    //int i = 0;
    //while (i < doctorList.Count)
    //{ 
    //    if (name == doctorList[i].firstName)
    //    {
    //        Doctor patient = new Doctor();
    //        doctorList[i].numbersOfPatients++;
    //        patient.firstName = doctorList[i].firstName;
    //        patient.lastName = doctorList[i].lastName;
    //        patient.position = doctorList[i].position;
    //        patient.numbersOfPatients = doctorList[i].numbersOfPatients;
    //        patient.birthYear = doctorList[i].birthYear;
    //        writer.Write($",FIRST NAME:{patient.firstName} LAST NAME:{patient.lastName}" +
    //        $" POSITION:{patient.position} NUMBERS OF PETIENS:{patient.numbersOfPatients}" +
    //        $" BIRTH YEAR:{patient.birthYear}\n");
    //        //doctorList.Add(patient);
    //    }
    //array = new Doctor[] { doctorList[i]};
    //i++;
    //}

}
// two-dimensional array diary \\
void TwoDimensionalArray()
{
    Random random = new Random();
    for(int i=0;i< diary.GetLength(0); i++)
    {
        for(int j = 0; j < diary.GetLength(1); j++)
        {
            diary[i, j] = random.Next(0, 10);
            diary[i, 6] = 0;
            Console.Write(diary[i,j]);
        }
        Console.WriteLine();
    }
}
// two-dimensional array diary Lower Five\\
void TwoDimensionalArrayLowerFive()
{
    Random random = new Random();
    for (int i = 0; i < diary.GetLength(0); i++)
    {
        for (int j = 0; j < diary.GetLength(1); j++)
        {
            diary[i, j] = random.Next(0, 10);
            diary[i, 6] = 0;
            if(diary[i, j]< 5)
            {
            Console.Write(diary[i, j]);
            }
            else
            {
                Console.Write("bussy");
            } 
        }
        Console.WriteLine();
    }
}
// main function \\
void MainFunction()
{
    ClinicOption();
    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            CreateNewObject();
            break;
        case 2:
            //AddPetientToDoctor(Console.ReadLine());
            break;
        case 3:
            PresentDoctorByName(Console.ReadLine());
            break;
        case 4:
            PresentAllDoctors();
            break;
        case 5:
            TwoDimensionalArray();
            break;
        case 6:
            TwoDimensionalArrayLowerFive();
            break;
        default:
            break;
    }
}

/// 
//Schedule schedule = new Schedule();
//schedule.diary = new int[int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())];
//schedule.TwoDimensionalArrayLowerFive();