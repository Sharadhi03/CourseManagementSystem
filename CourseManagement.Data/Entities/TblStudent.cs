using System;
using System.Collections.Generic;

namespace CourseManagement.Data.Entities;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public string? Courses { get; set; }

    public int? CourseId { get; set; }

    public virtual TblCourse? Course { get; set; }
}
