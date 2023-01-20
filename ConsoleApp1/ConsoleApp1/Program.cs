using System;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int ISBN { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsReserved { get; set; }
    public bool IsDamaged { get; set; }
    public DateTime PurchaseDate { get; set; }
    public DateTime DueDate { get; set; }
    public Employee Employee { get; set; }
    public User User { get; set; }

    public void CheckOut(User user)
    {
        if (!IsAvailable || IsReserved)
        {
            Console.WriteLine("Book is not available for checkout");
            return;
        }

        IsAvailable = false;
        User = user;
        DueDate = DateTime.Now.AddDays(5);
    }

    public void CheckIn()
    {
        if (IsAvailable)
        {
            Console.WriteLine("Book is already checked in");
            return;
        }

        if (DateTime.Now > DueDate)
        {
            Console.WriteLine("Book is overdue");
            User.Suspend();
        }

        IsAvailable = true;
        User = null;
        DueDate = DateTime.MinValue;
    }

    public void Reserve(User user)
    {
        if (!IsAvailable)
        {
            Console.WriteLine("Book is not available for reservation");
            return;
        }

        IsAvailable = false;
        IsReserved = true;
        User = user;
    }

    public void Extend()
    {
        if (IsReserved)
        {
            Console.WriteLine("Book is reserved and cannot be extended");
            return;
        }

        DueDate = DueDate.AddDays(3);
    }

    public void Damage()
    {
        IsDamaged = true;
        IsAvailable = false;
        User.Suspend();
    }

    public void Repair()
    {
        IsDamaged = false;
        IsAvailable = true;
    }

    public void Archive()
    {
        if (DateTime.Now.Subtract(PurchaseDate).TotalDays > 8 * 365)
        {
            Console.WriteLine("Book is archived due to age");
        }
    }
}

class Employee
{
    public string Name { get; set; }
    public int EmployeeId { get; set; }

    public void RegisterBook(Book book)
    {
        
    }
}

class User
{
    public string Name { get; set; }
    public int UserId { get; set; }
    public bool IsSuspended { get; set; }

    public void Suspend()
    {
        IsSuspended = true;
    }

    public void RequestBook(string title)
    {
  
    }
}