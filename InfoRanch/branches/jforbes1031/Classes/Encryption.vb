Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Namespace Util
    Public Class Encryption
        Private key() As Byte = {3, 4, 7, 13, 19, 21, 37, 55, 123, 230, 12, 8, 69, 23, 76, 77, 1, 5, 254, 44, 51, 99, 100, 113}
        Private iv() As Byte = {89, 13, 3, 6, 4, 101, 21, 99}

        Public Function Encrypt(ByVal inputText As String) As Byte()
            'Encode in UTF8 so GetByte can be used
            Dim utf8encoder As UTF8Encoding = New UTF8Encoding()
            Dim inputInBytes() As Byte = utf8encoder.GetBytes(inputText)

            'Create Encryption Provider
            Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

            'Set up Encryption with Key and IV
            Dim cTransform As ICryptoTransform = tdesProvider.CreateEncryptor(Me.key, Me.iv)

            'Must use a stream for encryption functions
            Dim encryptedStream As MemoryStream = New MemoryStream()
            Dim cryptStream As CryptoStream = New CryptoStream(encryptedStream, cTransform, CryptoStreamMode.Write)

            'Write to stream and then flush the buffer
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
            cryptStream.FlushFinalBlock()
            encryptedStream.Position = 0

            'Put stream back in byte array to return it
            Dim result(encryptedStream.Length - 1) As Byte
            encryptedStream.Read(result, 0, encryptedStream.Length)
            cryptStream.Close()
            Return result
        End Function

        Public Function Decrypt(ByVal inputInBytes() As Byte) As String
            'UTFEncoding to turn Byte array into a string
            Dim utf8encoder As UTF8Encoding = New UTF8Encoding()
            Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()

            'Provide Key and IV
            Dim cTransform As ICryptoTransform = tdesProvider.CreateDecryptor(Me.key, Me.iv)

            'Provide memory stream
            Dim decryptedStream As MemoryStream = New MemoryStream()
            Dim cryptStream As CryptoStream = New CryptoStream(decryptedStream, cTransform, CryptoStreamMode.Write)
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
            cryptStream.FlushFinalBlock()
            decryptedStream.Position = 0

            'Convert stream to string
            Dim result(decryptedStream.Length - 1) As Byte
            decryptedStream.Read(result, 0, decryptedStream.Length)
            cryptStream.Close()
            Dim myutf As UTF8Encoding = New UTF8Encoding()
            Return myutf.GetString(result)
        End Function
    End Class
End Namespace

