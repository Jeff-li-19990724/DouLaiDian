using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonInfo
{
   public class Person
    {
        string m_Index;

        public string Index
        {
            get { return m_Index; }
            set { m_Index = value; }
        }
        string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        string m_Sex;

        public string Sex
        {
            get { return m_Sex; }
            set { m_Sex = value; }
        }
        string m_Duty;

        public string Duty
        {
            get { return m_Duty; }
            set { m_Duty = value; }
        }
        string m_Birth;

        public string Birth
        {
            get { return m_Birth; }
            set { m_Birth = value; }
        }
        string m_Description;

        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

        string m_Image;

        public string Image
        {
            get { return m_Image; }
            set { m_Image = value; }
        }
    }
}