using System;

namespace Desktop.Models;

public class Question
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateDate { get; set; }
}