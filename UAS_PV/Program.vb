Imports System
Imports System.Collections.Generic
Imports System.IO

Module EBusiness
    Sub Main()
        ' Menggunakan jendela watch untuk memantau variabel
        Dim products As New List(Of Product)()
        Dim continueRunning As Boolean = True

        ' Menambahkan produk
        Try
            products.Add(New Product("Laptop", 1500.0, DateTime.Now))
            products.Add(New Product("Smartphone", 800.0, DateTime.Now))
            products.Add(New Product("Tablet", 300.0, DateTime.Now))
        Catch ex As Exception
            Console.WriteLine("Error adding products: " & ex.Message)
        End Try

        ' Menampilkan produk
        While continueRunning
            Console.WriteLine("Daftar Produk:")
            For Each product In products
                Console.WriteLine(product.ToString())
            Next

            ' Menggunakan Select Case untuk memilih tindakan
            Console.WriteLine("Pilih tindakan: 1. Tambah Produk 2. Hapus Produk 3. Keluar")
            Dim choice As Integer = Convert.ToInt32(Console.ReadLine())

            Select Case choice
                Case 1
                    ' Menambahkan produk baru
                    Try
                        Console.Write("Masukkan nama produk: ")
                        Dim name As String = Console.ReadLine()
                        Console.Write("Masukkan harga produk: ")
                        Dim price As Double = Convert.ToDouble(Console.ReadLine())
                        products.Add(New Product(name, price, DateTime.Now))
                    Catch ex As Exception
                        Console.WriteLine("Error adding product: " & ex.Message)
                    End Try

                Case 2
                    ' Menghapus produk
                    Try
                        Console.Write("Masukkan nama produk yang ingin dihapus: ")
                        Dim name As String = Console.ReadLine()
                        Dim productToRemove = products.Find(Function(p) p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        If productToRemove IsNot Nothing Then
                            products.Remove(productToRemove)
                            Console.WriteLine("Produk dihapus.")
                        Else
                            Console.WriteLine("Produk tidak ditemukan.")
                        End If
                    Catch ex As Exception
                        Console.WriteLine("Error removing product: " & ex.Message)
                    End Try

                Case 3
                    continueRunning = False

                Case Else
                    Console.WriteLine("Pilihan tidak valid.")
            End Select
        End While

        Console.WriteLine("Program selesai. Tekan sembarang tombol untuk keluar.")
        Console.ReadKey()
    End Sub

    ' Fungsi untuk menyimpan produk ke file
    Sub SaveProductsToFile(products As List(Of Product))
        Dim filePath As String = "products.txt"
        Using writer As New StreamWriter(filePath)
            For Each product In products
                writer.WriteLine(product.ToString())
            Next
        End Using
        Console.WriteLine("Data produk disimpan ke " & filePath)
    End Sub

    ' Kelas produk
    Class Product
        Public Property Name As String
        Public Property Price As Double
        Public Property DateAdded As DateTime

        Public Sub New(name As String, price As Double, dateAdded As DateTime)
            Me.Name = name
            Me.Price = price
            Me.DateAdded = dateAdded
        End Sub

        Public Overrides Function ToString() As String
            Return String.Format("Nama: {0}, Harga: {1}, Tanggal Ditambahkan: {2}", Name, Price, DateAdded)
        End Function
    End Class
End Module