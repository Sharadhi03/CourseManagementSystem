using System;
using System.Collections.Generic;

namespace CourseManagement.Data.Entities;

public partial class TblCourse
{
    public int CourseId { get; set; }

    public string? Name { get; set; }

    public int? Duration { get; set; }

    public int? MinimumMarks { get; set; }

    public int? MaximumMarks { get; set; }

    public virtual ICollection<TblStudent> TblStudents { get; } = new List<TblStudent>();
}
