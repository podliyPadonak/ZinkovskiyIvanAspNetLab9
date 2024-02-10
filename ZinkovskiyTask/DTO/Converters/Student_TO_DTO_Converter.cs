namespace ZinkovskiyTask.DTO.Converters
{
    public static class Student_TO_DTO_Converter
    {
        public static Student ToStudent(this Student_DTO student_dto)
        {
            Student student = new Student();
            student.Id = student_dto.Id;
            student.Name = student_dto.Name;
            student.Age = student_dto.Age;
            return student;
        }
        public static Student ToStudent(this StudentAddUpdate_DTO student_dto)
        {
            Student student = new Student();
            student.Name = student_dto.Name;
            student.Age = student_dto.Age;
            return student;
        }
    }
}
