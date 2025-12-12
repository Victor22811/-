using System;

public class CircularBuffer<T>
{
    private readonly T[] _buffer;
    private int _head = 0;     // куда читаем (старейший элемент)
    private int _tail = 0;     // куда пишем (следующая свободная ячейка)
    private int _count = 0;    // количество элементов в буфере

    public CircularBuffer(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero.");

        _buffer = new T[capacity];
    }

    // Добавление элемента, если есть место
    // Если буфер полон → InvalidOperationException
    public void Write(T value)
    {
        if (_count == _buffer.Length)
            throw new InvalidOperationException("Buffer is full.");

        _buffer[_tail] = value;
        _tail = (_tail + 1) % _buffer.Length;
        _count++;
    }

    // Принудительное добавление: если заполнен — перезаписываем старый
    public void Overwrite(T value)
    {
        if (_count == _buffer.Length)
        {
            // Перезапись старейшего (head)
            _buffer[_head] = value;
            _head = (_head + 1) % _buffer.Length; // старейший сдвигается
        }
        else
        {
            _buffer[_tail] = value;
            _count++;
        }

        _tail = (_tail + 1) % _buffer.Length;
    }

    // Чтение старейшего элемента
    public T Read()
    {
        if (_count == 0)
            throw new InvalidOperationException("Buffer is empty.");

        T val = _buffer[_head];
        _buffer[_head] = default!;
        _head = (_head + 1) % _buffer.Length;
        _count--;

        return val;
    }

    // Очистка буфера
    public void Clear()
    {
        Array.Clear(_buffer, 0, _buffer.Length);
        _head = 0;
        _tail = 0;
        _count = 0;
    }
}
