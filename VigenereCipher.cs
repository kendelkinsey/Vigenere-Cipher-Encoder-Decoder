using System.Text;

/**
 * Vigenere Ciper, takes 3 inputs from user based on the printed prompts
 */
public class cipher
{
    private static string keyWord;
    private static string word;

    private static void CipherDriver()
    {
        Console.WriteLine("Enter 1 to Encrypt, 2 to Decrypt: ");
        string option = Console.ReadLine();

        if (option == "1")
        {
            Console.WriteLine("Enter Word to Encrypt: ");
            word = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter encryption key: ");
            keyWord = Console.ReadLine().ToUpper();
            
            Encrypt();

        }
        else if (option == "2")
        {
            Console.WriteLine("Enter Word to Decrypt: ");
            word = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter encryption key: ");
            keyWord = Console.ReadLine().ToUpper();
            
            Decrypt();

        }
        else
        {
            Console.WriteLine("try again :(");
        }
    }

    private static void Encrypt()
    {
        if (word.Length > keyWord.Length)
        {
            keyWord = keywordConfig(keyWord);
        }
        StringBuilder encryptedWord = new StringBuilder();

        for (int i = 0; i < word.Length; i++)
        {
            int shift = keyWord[i] - 65;
            
            char newChar = (char)(word[i] + shift);
            if (newChar > 90)
            {
                newChar = (char)((newChar - 90) + 64) ;
            }

            encryptedWord.Append(newChar);
        }
        string encrypted = encryptedWord.ToString();
        Console.WriteLine("Your encrypted word is: " + encrypted);
    }

    private static string keywordConfig(string key)
    {
        StringBuilder tempKey = new StringBuilder(key);
        int counter = 0;
        while (counter <= word.Length)
        {
            tempKey.Append(key[counter % key.Length]);
            counter++;
        }
        string newKey = tempKey.ToString();
        return newKey;
    }

    private static void Decrypt()
    {
        if (word.Length > keyWord.Length)
        {
            keyWord = keywordConfig(keyWord);
        }
        StringBuilder decryptedWord = new StringBuilder();

        for (int i = 0; i < word.Length; i++)
        {
            int shift = keyWord[i] - 65;
            char newChar = (char)(word[i] - shift);
            if (newChar < 65)
            {
                newChar = (char)((newChar + 90) - 64);

            }
            decryptedWord.Append(newChar);
        }
        string decrypted = decryptedWord.ToString();
        Console.WriteLine("Your decrypted word is: " + decrypted);
    }
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CipherDriver();
    }
}