# TrashGenerator

Генератор бинарных файлов указанного размера.
Использовал для подготовки к нагрузочному тестированию системы документооборота.

Пример запуска программы:

`TrashGenerator.exe -fileCount=10 -fileSize=200000 -randsize=100 -fileExt=dat`

Будут использоваться следующие параметры:

1. `-fileCount= (Count Files)   : 10` — количество генерируемых файлов.
2. `-fileSize = (Size Files)    : 200000` — базовый размер новых файлов.
3. `-randSize = (Random Size)   : 100 (+/-)` — диапазон отклонений размера файлов от базового.
4. `-fileExt  = (File Extension): dat` — расширение файлов.
5. `-workPath = (Work Path)     : {текущая директория}` - в какой каталог помещать файлы.

Так программа сгенериует 10 файлов размером 200000±100 байт с расширением dat в текущей директории:

```
D:\Project\TrashGenerator\bin\Debug\File_200000_1.dat   200098 Bytes
D:\Project\TrashGenerator\bin\Debug\File_200000_2.dat   199948 Bytes
D:\Project\TrashGenerator\bin\Debug\File_200000_3.dat   199941 Bytes
D:\Project\TrashGenerator\bin\Debug\File_200000_4.dat   199959 Bytes
D:\Project\TrashGenerator\bin\Debug\File_200000_5.dat   199956 Bytes
D:\Project\TrashGenerator\bin\Debug\File_200000_6.dat   200068 Bytes
D:\Project\TrashGenerator\bin\Debug\File_200000_7.dat   199983 Bytes
D:\Project\TrashGenerator\bin\Debug\File_200000_8.dat   200069 Bytes
D:\Project\TrashGenerator\bin\Debug\File_200000_9.dat   199919 Bytes
D:\Project\TrashGenerator\bin\Debug\File_200000_10.dat  199926 Bytes
Press any key to continue . . .
```

Для генерации файлов фиксированного размера нужно указать `-randSize = 0`, например:

`TrashGenerator.exe -fileCount=5 -fileSize=1000 -randsize=0 -fileExt=bin`

Результат будет таким:

```
D:\Project\TrashGenerator\bin\Debug>TrashGenerator.exe -fileCount=5 -fileSize=1000 -randsize=0 -fileExt=bin
-fileCount= (Count Files)   : 5
-fileSize = (Size Files)    : 1000
-randSize = (Random Size)   : 0 (+/-)
-fileExt  = (File Extension): bin
-workPath = (Work Path)     : D:\Project\TrashGenerator\bin\Debug
D:\Project\TrashGenerator\bin\Debug\File_1000_1.bin     1000 Bytes
D:\Project\TrashGenerator\bin\Debug\File_1000_2.bin     1000 Bytes
D:\Project\TrashGenerator\bin\Debug\File_1000_3.bin     1000 Bytes
D:\Project\TrashGenerator\bin\Debug\File_1000_4.bin     1000 Bytes
D:\Project\TrashGenerator\bin\Debug\File_1000_5.bin     1000 Bytes
Press any key to continue . . .
```
