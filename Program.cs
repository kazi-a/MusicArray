namespace MusicArray
{
    public enum MusicGenre
    {
        Rock,
        Pop,
        HipHop,
        Jazz,
        Electronic
    }

    public struct Music
    {
        public string Title;
        public string Artist;
        public string Album;
        public int Length;
        public MusicGenre Genre;

        // Set methods
        public void SetArtist(string artist)
        {
            Artist = artist;
        }

        public void SetAlbum(string album)
        {
            Album = album;
        }

        public void SetGenre(MusicGenre genre)
        {
            Genre = genre;
        }

        // Display method
        public string Display()
        {
            return $"Title: {Title}\nArtist: {Artist}\nAlbum: {Album}\nLength: {Length} seconds\nGenre: {Genre}";
        }

        internal void SetTitle(string v)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many songs would you like to enter?");
            int size = int.Parse(Console.ReadLine());
            Music[] collection = new Music[size];

            try
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"Song {i + 1}");
                    collection[i].SetTitle(PromptInput("Title"));
                    collection[i].SetArtist(PromptInput("Artist"));
                    collection[i].SetAlbum(PromptInput("Album"));
                    collection[i].Length = int.Parse(PromptInput("Length (seconds)"));
                    collection[i].SetGenre(PromptGenre());
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Display songs
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"{collection[i].Display()}");
                }
            }
        }

        static string PromptInput(string prompt)
        {
            Console.WriteLine($"Please enter the {prompt}:");
            return Console.ReadLine();
        }

        static MusicGenre PromptGenre()
        {
            Console.WriteLine("Please enter the genre:");
            Console.WriteLine("0. Rock\n1. Pop\n2. HipHop\n3. Jazz\n4. Electronic");
            int genreIndex = int.Parse(Console.ReadLine());

            if (!Enum.IsDefined(typeof(MusicGenre), genreIndex))
            {
                throw new ArgumentException("Invalid genre index.");
            }

            return (MusicGenre)genreIndex;
        }
    }
}
