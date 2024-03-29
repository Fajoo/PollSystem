﻿namespace PollSystem.Application.CQRS;

public class Page
{
    public int Count { get; set; }
    public int CurrentPage { get; set; }
    public int Total { get; set; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < Total;
}