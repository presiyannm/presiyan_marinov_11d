using System;
using Microsoft.EntityFrameworkCore;
using presiyan_marinov_11d.Data;
using presiyan_marinov_11d.View;

namespace presiyan_marinov_11d
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var display = new Display();
            display.StartPresentation();
        }
    }
}
