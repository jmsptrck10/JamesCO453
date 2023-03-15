using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This enum represents the grades a student can achieve.
    /// </summary>
    public enum Grades
    {
        [Display(Name = "Fail")]
        [Description("Referred")]
        F,
        [Display(Name = "Third")]
        [Description("BSc(Hons) Third Class")]
        D,
        [Display(Name = "Lower Second")]
        [Description("BSc(Hons) Lower Second")]
        C,
        [Display(Name = "Upper Second")]
        [Description("BSc(Hons) Upper Second")]
        B,
        [Display(Name = "First")]
        [Description("BSc(Hons) First Class")]
        A
    }
}