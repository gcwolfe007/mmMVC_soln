mmMVC_soln
==========

MM Site
URLs for Study
Monday, May 21, 2018
10:45 AM
 
•	https://msdn.microsoft.com/en-us/library/system.threading.manualresetevent.aspx
•	https://docs.microsoft.com/en-us/dotnet/standard/threading/the-managed-thread-pool
•	https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-parallel-library-tpl
•	https://msdn.microsoft.com/en-us/library/system.threading.semaphore.aspx
•	https://msdn.microsoft.com/en-us/library/2awhba7a.aspx
•	https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/yield
•	https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/using-type-dynamic
•	https://msdn.microsoft.com/en-us/library/system.diagnostics.switch.aspx
•	https://blogs.msdn.microsoft.com/jmstall/2007/02/15/throw-e-vs-throw/
•	https://docs.microsoft.com/en-us/dotnet/framework/interop/packaging-an-assembly-for-com
•	https://msdn.microsoft.com/en-us/library/dd642243.aspx
•	https://docs.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes
•	https://msdn.microsoft.com/en-us/library/system.threading.thread.yield.aspx
•	https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern
•	https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern#basic_pattern
•	https://docs.microsoft.com/en-us/dotnet/standard/security/cryptographic-services
•	https://docs.microsoft.com/en-us/dotnet/standard/security/decrypting-data
•	https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-create-temporary-certificates-for-use-during-development
•	https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.match?view=netframework-4.7.1#System_Text_RegularExpressions_Regex_Match_System_String_System_Int32_System_Int32_
•	https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
 
 
 
Screen clipping taken: 5/22/2018 11:36 AM
 
 
 
 
Screen clipping taken: 5/22/2018 11:35 AM
 
 
 
Trace Switches
Monday, May 21, 2018
9:55 AM
 
 
 
Screen clipping taken: 5/21/2018 9:55 AM
 
 
 
 
Package assembly for COM
Monday, May 21, 2018
9:58 AM
 
 
Screen clipping taken: 5/21/2018 9:59 AM
 
 
 
Dispose Pattern
Monday, May 21, 2018
10:39 AM
 
 
 
Screen clipping taken: 5/21/2018 10:40 AM
 
✓ DO declare a protected virtual void Dispose(bool disposing) method to centralize all logic related to releasing unmanaged resources.
 
Pasted from <https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern#basic_pattern> 
 
✓ DO implement the IDisposable interface by simply calling Dispose(true) followed by GC.SuppressFinalize(this).
 
Pasted from <https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern#basic_pattern> 
 
X DO NOT make the parameterless Dispose method virtual.
The Dispose(bool) method is the one that should be overridden by subclasses.
 
Pasted from <https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern#basic_pattern> 
 
X DO NOT declare any overloads of the Dispose method other than Dispose() and Dispose(bool).
Dispose should be considered a reserved word to help codify this pattern and prevent confusion among implementers, users, and compilers. Some languages might choose to automatically implement this pattern on certain types.
 
Pasted from <https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern#basic_pattern> 
 
 
The Boolean parameter disposing indicates whether the method was invoked from the IDisposable.Dispose implementation or from the finalizer. The Dispose(bool) implementation should check the parameter before accessing other reference objects (e.g., the resource field in the preceding sample). Such objects should only be accessed when the method is called from the IDisposable.Disposeimplementation (when the disposing parameter is equal to true). If the method is invoked from the finalizer (disposing is false), other objects should not be accessed. The reason is that objects are finalized in an unpredictable order and so they, or any of their dependencies, might already have been finalized.
 
Pasted from <https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/dispose-pattern#basic_pattern> 
 
 
Screen clipping taken: 5/22/2018 11:22 AM
 
 
 
 
MakeCert.exe
Tuesday, May 22, 2018
12:31 PM
 
 
 
Screen clipping taken: 5/22/2018 12:33 PM
 
 
 
Screen clipping taken: 5/22/2018 12:34 PM
 
 
 
Cryptographic Services
Tuesday, May 22, 2018
2:01 PM
Secret-Key Encryption
Secret-key encryption algorithms use a single secret key to encrypt and decrypt data. You must secure the key from access by unauthorized agents, because any party that has the key can use it to decrypt your data or encrypt their own data, claiming it originated from you.
Secret-key encryption is also referred to as symmetric encryption because the same key is used for encryption and decryption. Secret-key encryption algorithms are very fast (compared with public-key algorithms) and are well suited for performing cryptographic transformations on large streams of data. Asymmetric encryption algorithms such as RSA are limited mathematically in how much data they can encrypt. Symmetric encryption algorithms do not generally have those problems.
 
Pasted from <https://docs.microsoft.com/en-us/dotnet/standard/security/cryptographic-services#primitives> 
 
•	AesManaged (introduced in the .NET Framework 3.5).
•	DESCryptoServiceProvider.
•	HMACSHA1 (This is technically a secret-key algorithm because it represents message authentication code that is calculated by using a cryptographic hash function combined with a secret key. See Hash Values, later in this topic.)
•	RC2CryptoServiceProvider.
•	RijndaelManaged.
•	TripleDESCryptoServiceProvider.
 
Pasted from <https://docs.microsoft.com/en-us/dotnet/standard/security/cryptographic-services#primitives> 
 
 
Public-Key Encryption
Public-key encryption uses a private key that must be kept secret from unauthorized users and a public key that can be made public to anyone. The public key and the private key are mathematically linked; data that is encrypted with the public key can be decrypted only with the private key, and data that is signed with the private key can be verified only with the public key. The public key can be made available to anyone; it is used for encrypting data to be sent to the keeper of the private key. Public-key cryptographic algorithms are also known as asymmetric algorithms because one key is required to encrypt data, and another key is required to decrypt data. A basic cryptographic rule prohibits key reuse, and both keys should be unique for each communication session. However, in practice, asymmetric keys are generally long-lived.
 
Pasted from <https://docs.microsoft.com/en-us/dotnet/standard/security/cryptographic-services#primitives> 
•	DSACryptoServiceProvider
•	RSACryptoServiceProvider
•	ECDiffieHellman (base class)
•	ECDiffieHellmanCng
•	ECDiffieHellmanCngPublicKey (base class)
•	ECDiffieHellmanKeyDerivationFunction (base class)
•	ECDsaCng
 
Pasted from <https://docs.microsoft.com/en-us/dotnet/standard/security/cryptographic-services#primitives> 
 
Digital Signatures
Public-key algorithms can also be used to form digital signatures. Digital signatures authenticate the identity of a sender (if you trust the sender's public key) and help protect the integrity of data. Using a public key generated by Alice, the recipient of Alice's data can verify that Alice sent it by comparing the digital signature to Alice's data and Alice's public key.
To use public-key cryptography to digitally sign a message, Alice first applies a hash algorithm to the message to create a message digest. The message digest is a compact and unique representation of data. Alice then encrypts the message digest with her private key to create her personal signature. Upon receiving the message and signature, Bob decrypts the signature using Alice's public key to recover the message digest and hashes the message using the same hash algorithm that Alice used. If the message digest that Bob computes exactly matches the message digest received from Alice, Bob is assured that the message came from the possessor of the private key and that the data has not been modified. If Bob trusts that Alice is the possessor of the private key, he knows that the message came from Alice.
 
The .NET Framework provides the following classes that implement digital signature algorithms:
•	DSACryptoServiceProvider
•	RSACryptoServiceProvider
•	ECDsa (base class)
•	ECDsaCng
 
Pasted from <https://docs.microsoft.com/en-us/dotnet/standard/security/cryptographic-services#primitives> 
Hash Values
Hash algorithms map binary values of an arbitrary length to smaller binary values of a fixed length, known as hash values. A hash value is a numerical representation of a piece of data. If you hash a paragraph of plaintext and change even one letter of the paragraph, a subsequent hash will produce a different value. If the hash is cryptographically strong, its value will change significantly. For example, if a single bit of a message is changed, a strong hash function may produce an output that differs by 50 percent. Many input values may hash to the same output value. However, it is computationally infeasible to find two distinct inputs that hash to the same value.
Two parties (Alice and Bob) could use a hash function to ensure message integrity. They would select a hash algorithm to sign their messages. Alice would write a message, and then create a hash of that message by using the selected algorithm. They would then follow one of the following methods:
•	Alice sends the plaintext message and the hashed message (digital signature) to Bob. Bob receives and hashes the message and compares his hash value to the hash value that he received from Alice. If the hash values are identical, the message was not altered. If the values are not identical, the message was altered after Alice wrote it.
Unfortunately, this method does not establish the authenticity of the sender. Anyone can impersonate Alice and send a message to Bob. They can use the same hash algorithm to sign their message, and all Bob can determine is that the message matches its signature. This is one form of a man-in-the-middle attack. See NIB: Cryptography Next Generation (CNG) Secure Communication Example for more information.
•	Alice sends the plaintext message to Bob over a nonsecure public channel. She sends the hashed message to Bob over a secure private channel. Bob receives the plaintext message, hashes it, and compares the hash to the privately exchanged hash. If the hashes match, Bob knows two things:
•	The message was not altered.
•	The sender of the message (Alice) is authentic.
For this system to work, Alice must hide her original hash value from all parties except Bob.
•	Alice sends the plaintext message to Bob over a nonsecure public channel and places the hashed message on her publicly viewable Web site.
This method prevents message tampering by preventing anyone from modifying the hash value. Although the message and its hash can be read by anyone, the hash value can be changed only by Alice. An attacker who wants to impersonate Alice would require access to Alice's Web site.
None of the previous methods will prevent someone from reading Alice's messages, because they are transmitted in plaintext. Full security typically requires digital signatures (message signing) and encryption.
The .NET Framework provides the following classes that implement hashing algorithms:
•	HMACSHA1.
•	MACTripleDES.
•	MD5CryptoServiceProvider.
•	RIPEMD160.
•	SHA1Managed.
•	SHA256Managed.
•	SHA384Managed.
•	SHA512Managed.
