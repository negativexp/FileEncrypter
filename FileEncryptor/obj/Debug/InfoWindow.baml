   M S B A M L   `   `   `  ����H  DFileEncryptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FileEncryptorFileEncryptor  5   	       FileEncryptor.InfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:FileEncryptor     5   	     � Title$  Created by 192.168.0.1��5   	   $	��425��6(   $	��425��65    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$ 
ToolWindow=�6   .��5
      � .+�5   
   � $��30��6   $	��Top=�6   .+�5      �� $��AES encryption/decryption��6   $��20(�69   $��Segoe UI)�6G   $��Center=�6]   $��Center=�6z   5      � 5   
   $	��354��6   $��Bottom=�6   .+�5      �� 
���   �$��1q�6)   $	��171��6=   $	��Top=�6J   $��5q�6b   ._�5      � .+�5      �� $��
How to use��6    $��16(�62   $��Segoe UI)�6@   $��Center=�6V   $	��Top=�6s   �� 5      $����To start using the program, you will first have to get files to encrypt, drag and drop them to continue. Create your salt bytes, it should contain 8+ bytes (don't use spacebar to seperate them). Then choose block size and key size and last thing to do is to create your password. You will not be able to decrypt the data unless the salt bytes, block size, key size and password are correct. If you want to decrypt your data just repeat the process.��6    $��12(�6�  $��Segoe UI)�6�  $��25,25,25,10q�6  $
��Wrap=�6!  5      5      �� 5      $	��171��6   $��5q�6"   
���   �$��1q�6A   $��Bottom=�6U   ._�5      � .+�5      �� $��Useful Information��6    $��16(�6:   $��Segoe UI)�6H   $��Center=�6^   $	��Top=�6{   �� 5      $����Advanced Encryption Standard is a standardized algorithm used to encrypt data in computer science. It is a symmetric block cipher that encrypts and decrypts data divided into blocks of a fixed length with the same key.��6    $��12(�6  $��Segoe UI)�6  $��25,25,25,80q�6'  $
��Wrap=�6<  �� 5      $%��Block size:  128, 192, 256 bits��6    $��12(�6H   $��Segoe UI)�6V   $
��Wrap=�6l   $��
0,103,0,51q�6�   $��Center=�6�   �� 5      $&�� Key size:     128, 192, 256 bits��6    $��12(�6I   $��Segoe UI)�6W   $
��Wrap=�6m   $��
0,119,0,35q�6�   $��Center=�6�   �� 5      $%��Salt bytes:     8 or more bytes��6    $��12(�6H   $��Segoe UI)�6V   $
��Wrap=�6l   $��
0,135,0,19q�6�   $��Center=�6�   5      5      5      5       5!      