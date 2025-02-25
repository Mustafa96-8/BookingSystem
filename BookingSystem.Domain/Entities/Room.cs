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

    private Room(string description, Price price, RoomType roomType, IEnumerable<Сonvenience> сonveniences)
    {
        Description = description;
        this.price = price;
        this.roomType = roomType;
        this.сonveniences = сonveniences;
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
    public IEnumerable<Сonvenience> сonveniences { get; private set; } = [];

    /// <summary>
    /// TO DO: Добавить Валидацию
    /// </summary>
    public static Result<Room,Error> Create(string description, Price price, RoomType roomType, IEnumerable<Сonvenience> сonveniences)
    {
        if(description == null|| price==null||roomType==null|| сonveniences == null)
        {
            return Errors.General.ValueIsRequired();
        }
        return new Room(description, price, roomType, сonveniences);
    } 
}
