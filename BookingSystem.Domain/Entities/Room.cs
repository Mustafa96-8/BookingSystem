using BookingSystem.Domain.Collections;
using BookingSystem.Domain.Common;
using BookingSystem.Domain.ValueObjects;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities;

public class Room : Entity
{
    private Room() { }

    private Room(string description, Price price, RoomType roomType, IEnumerable<Сonvenience> conveniences)
    {
        Description = description;
        this.price = price;
        this.roomType = roomType;
        this.conveniences = conveniences;
    }
    /// <summary>
    /// Описание комнаты
    /// </summary>
    public string Description { get; private set; }
    /// <summary>
    /// Цена
    /// </summary>
    public Price price { get; private set; }
    /// <summary>
    /// Тип комнаты
    /// </summary>
    public RoomType roomType { get; private set; } = RoomType.Single;
    /// <summary>
    /// Удобства
    /// </summary>
    public IEnumerable<Сonvenience> conveniences { get; private set; } = [];
    /// <summary>
    /// Создание экземпляра комнаты
    /// </summary>
    /// <param name="description">Описание комнаты</param>
    /// <param name="price">Цена за номер <seealso cref="Price"/></param>
    /// <param name="roomType">Тип номера в формате <seealso cref="Collections.RoomType"/> </param>
    /// <param name="conveniences">Массив удобств в формате перечисления <seealso cref="Collections.Сonvenience"/></param>
    /// <returns>Новая комната</returns>
    public static Result<Room,Error> Create(string description, Price price, RoomType roomType, IEnumerable<Сonvenience> conveniences)
    {
       return new Room(description, price, roomType, conveniences);
    } 
}
