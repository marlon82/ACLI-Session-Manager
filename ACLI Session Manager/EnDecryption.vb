Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Aes
Imports System.Text

Public Module clsEnDecryption

#Region "File encryption"

    'Private Sub Encrypt(inputFilePath As String, outputfilePath As String)
    '    Dim EncryptionKey As String = "MAKV2SPBNI99212"
    '    Using encryptor As Aes = Aes.Create()
    '        Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
    '         &H65, &H64, &H76, &H65, &H64, &H65,
    '         &H76})
    '        encryptor.Key = pdb.GetBytes(32)
    '        encryptor.IV = pdb.GetBytes(16)
    '        Using fs As New FileStream(outputfilePath, FileMode.Create)
    '            Using cs As New CryptoStream(fs, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
    '                Using fsInput As New FileStream(inputFilePath, FileMode.Open)
    '                    Dim data As Integer
    '                    While (Assign(data, fsInput.ReadByte())) <> -1
    '                        cs.WriteByte(CByte(data))
    '                    End While
    '                End Using
    '            End Using
    '        End Using
    '    End Using
    'End Sub

    'Private Sub Decrypt(inputFilePath As String, outputfilePath As String)
    '    Dim EncryptionKey As String = "MAKV2SPBNI99212"
    '    Using encryptor As Aes = Aes.Create()
    '        Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
    '         &H65, &H64, &H76, &H65, &H64, &H65,
    '         &H76})
    '        encryptor.Key = pdb.GetBytes(32)
    '        encryptor.IV = pdb.GetBytes(16)
    '        Using fs As New FileStream(inputFilePath, FileMode.Open)
    '            Using cs As New CryptoStream(fs, encryptor.CreateDecryptor(), CryptoStreamMode.Read)
    '                Using fsOutput As New FileStream(outputfilePath, FileMode.Create)
    '                    Dim data As Integer
    '                    While (Assign(data, cs.ReadByte())) <> -1
    '                        fsOutput.WriteByte(CByte(data))
    '                    End While
    '                End Using
    '            End Using
    '        End Using
    '    End Using
    'End Sub

#End Region


#Region "String encryption"

    Dim aeskey As String = "09325hiaf/T/(§gui23vatq3ab2q4ivq"

    Public Function ObfuscateString(str As String) As String
        Return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(str))
    End Function

    Public Function DeObfuscateString(str As String) As String
        Return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(str))
    End Function

    Public Sub EncryptFile_Aes(fullpath As String, plaintext As String)
        Dim cryptString As String
        'encrypt string
        cryptString = EncryptString_Aes(plaintext)
        Using sw As StreamWriter = New StreamWriter(fullpath, False)
            sw.Write(cryptString)
            sw.Close()
        End Using
    End Sub

    ''' <summary>
    ''' Encrypts data with the hardcoded key and new IV
    ''' </summary>
    ''' <param name="plainText">Readable string to be encrypted</param>
    ''' <returns>Returns bytes as string with first 16 being the IV</returns>
    ''' <remarks></remarks>
    Public Function EncryptString_Aes(ByVal plainText As String) As String
        Dim sb As StringBuilder = New StringBuilder()
        ' Create an AesCryptoServiceProvider object
        ' with the specified key and IV.
        Using aesAlg As New AesCryptoServiceProvider()

            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(aeskey))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)

            aesAlg.Key = hash
            aesAlg.GenerateIV()

            ' Create a decrytor to perform the stream transform.
            Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)

            ' Create the streams used for encryption.
            Dim msEncrypt As New MemoryStream()

            Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                Using swEncrypt As New StreamWriter(csEncrypt)
                    'Write all data to the stream.
                    swEncrypt.Write(plainText)
                End Using
                sb.Append(BitConverter.ToString(aesAlg.IV))
                sb.Append(BitConverter.ToString(msEncrypt.ToArray))
            End Using
        End Using

        Return sb.ToString.Replace("-", "")
    End Function 'EncryptStringToBytes_Aes

    Public Function DecryptFile_Aes(ByVal fullpath As String) As String
        Using sr As StreamReader = New StreamReader(fullpath)
            Dim answerValue As String = DecryptString_Aes(sr.ReadToEnd)
            sr.Close()
            Return answerValue
        End Using
    End Function

    ''' <summary>
    ''' Pass a string of contiguous bytes with leading 16 IV
    ''' </summary>
    ''' <param name="hexString"></param>
    ''' <returns>Plain text string</returns>
    ''' <remarks></remarks>
    Public Function DecryptString_Aes(ByVal hexString As String) As String
        If hexString.Length = 0 Then
            Return ""
        End If

        Dim plaintext As String = Nothing
        Dim iv(15) As Byte
        Dim cryptBytes As Byte() = {0}

        Dim itemindex As Integer = 0
        For i As Integer = 1 To Len(hexString) Step 2
            If itemindex <= 15 Then
                iv(itemindex) = Byte.Parse(Mid(hexString, i, 2), Globalization.NumberStyles.HexNumber)
            Else
                ReDim Preserve cryptBytes(itemindex - 16)
                cryptBytes(itemindex - 16) = Byte.Parse(Mid(hexString, i, 2), Globalization.NumberStyles.HexNumber)
            End If
            itemindex += 1
        Next


        Try
            Using aesAlg As New AesCryptoServiceProvider()
                Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
                Dim hash(31) As Byte
                Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(aeskey))
                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)

                aesAlg.Key = hash
                aesAlg.IV = iv
                ' Create a decrytor to perform the stream transform.
                Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)
                ' Create the streams used for decryption.
                Using msDecrypt As New MemoryStream(cryptBytes)
                    Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                        Using srDecrypt As New StreamReader(csDecrypt)
                            ' Read the decrypted bytes from the decrypting stream
                            ' and place them in a string.
                            plaintext = srDecrypt.ReadToEnd()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            plaintext = Nothing
        End Try
        Return plaintext
    End Function 'DecryptString_Aes 
#End Region

    '
    Public Function MD5StringHash(ByVal strString As String) As String
        Dim MD5 As New MD5CryptoServiceProvider
        Dim Data As Byte()
        Dim Result As Byte()
        Dim Res As String = ""
        Dim Tmp As String = ""

        Data = Encoding.ASCII.GetBytes(strString)
        Result = MD5.ComputeHash(Data)
        For i As Integer = 0 To Result.Length - 1
            Tmp = Hex(Result(i))
            If Len(Tmp) = 1 Then Tmp = "0" & Tmp
            Res += Tmp
        Next
        Return Res
    End Function

End Module
