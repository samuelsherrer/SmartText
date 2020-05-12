using System;
using System.Collections.Generic;
using System.Text;

namespace SmartText
{
    public interface IContentReader
    {
        string[] ReadAllLines(string filePath);
    }
}
