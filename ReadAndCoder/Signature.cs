﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndCoder {
    class Signature
    {
        // для хранения сигнатуры используем словарь с ключами-номерами частей
        // и значениями-байтовыми хеш-массивами
        private SortedDictionary<Int64, byte[]> _signature;

        internal Signature(long countOfParts)
        {
            // создаём объект-словарь
            _signature = new SortedDictionary<long, byte[]>();
        }

        // возвращаем наш словарь c сигнатурами
        internal SortedDictionary<Int64, byte[]> GetSignature()
        {
            return _signature;
        }

        // для указанной части добавляем байтовую сигнатуру
        internal void AddPartSignature(long part, byte[] signBytes)
        {
            _signature.Add(part, signBytes);
        }

    }
}