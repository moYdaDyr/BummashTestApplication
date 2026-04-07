using System.ComponentModel.DataAnnotations;

namespace BummashTestApplication
{
    public class InitialDetailModel : IInitialDetailModel
    {
        [Required(ErrorMessage = "Не указан внешний диаметр")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Внешний диаметр должен быть положительным")]
        public int DiameterOuter { get; set; }

        [Required(ErrorMessage = "Не указан внутренний диаметр")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Внутренний диаметр должен быть положительным")]
        public int DiameterInner { get; set; }

        [Required(ErrorMessage = "Не указана высота")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Высота должна быть положительной")]
        public int Height { get; set; }

        [Required(ErrorMessage = "Не указано количество деталей")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Количество деталей должно быть положительным")]
        public int NumberOfDetails { get; set; }

        [Required(ErrorMessage = "Не указана длина реза")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Длина реза должна быть положительной")]
        public int CutLength { get; set; }

        [Required(ErrorMessage = "Не указан напуск на пробу")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Напуск на пробу должен быть неотрицательным")]
        public int ProbingOverlap { get; set; }

        [Required(ErrorMessage = "Не указан напуск на термообработку")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Напуск на термообработку должен быть неотрицательным")]
        public int ThermoOverlap { get; set; }
    }
}
