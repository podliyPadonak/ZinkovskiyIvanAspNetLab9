namespace ZinkovskiyTask.DTO.Converters
{
    public static class Student_FROM_DTO_Converter
    {
        public static Student_DTO ToStudentDTO(this Student student)
        {
            var student_dto = new Student_DTO();
            student_dto.Id = student.Id;
            student_dto.Name = student.Name;
            student_dto.Age = student.Age;
            return student_dto;
        }
        public static StudentAddUpdate_DTO ToStudentAddUpdateDTO(this Student student)
        {
            var student_add_update_dto = new StudentAddUpdate_DTO();
            student_add_update_dto.Name = student.Name;
            student_add_update_dto.Age = student.Age;
            return student_add_update_dto;
        }
    }
}
