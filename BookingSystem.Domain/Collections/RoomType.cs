using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Collections;
/// <summary>
/// Перечисление возможных типов номеров в отелях (Одноместный, Двухместный с одной кроватью, С двумя кроватями...)
/// </summary>
public enum RoomType
{
    /// <summary>
    /// Одноместный 
    /// </summary>
    Single,
    /// <summary>
    /// Двухместный с одной кроватью
    /// </summary>
    Double,
    /// <summary>
    /// Двухместный с двумя кроватями
    /// </summary>
    Twin,
    /// <summary>
    /// Трехместный 
    /// </summary>
    Triple,
    /// <summary>
    /// Четырехместный 
    /// </summary>
    Quadriple,

}
