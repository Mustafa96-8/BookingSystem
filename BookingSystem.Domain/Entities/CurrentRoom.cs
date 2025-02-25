﻿using BookingSystem.Domain.Common;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities;

public class CurrentRoom :Entity
{
    private CurrentRoom(int number, IEnumerable<byte> photos,Room room)
    {
        this.number = number;
        Photos = photos;
        this.room = room;
    }

    /// <summary>
    /// Номер комнаты в отеле
    /// </summary>
    public int number { get; private set; } = 0;
    /// <summary>
    /// Фотографии комнаты
    /// </summary>
    public IEnumerable<byte> Photos { get; private set; } = [];
    /// <summary>
    /// Стандартная комната
    /// </summary>
    public Room room { get; private set; }
    /// <summary>
    /// TO DO: Добавить Валидацию
    /// </summary>
    public static Result<CurrentRoom, Error> Create(int number, IEnumerable<byte> photos,Room room) => new CurrentRoom(number, photos, room);

}
