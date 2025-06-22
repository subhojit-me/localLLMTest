using LLama;
using LLama.Common;

namespace AIWindow
{
    public partial class Form1 : Form
    {
        public string ModelPath { get; set; }
        ChatHistory chatHistory;
        ChatSession chatSession;
        //InferenceParams inferenceParams;

        public Form1()
        {
            InitializeComponent();

            ModelPath = AppDomain.CurrentDomain.BaseDirectory + "Qwen3-0.6B-BF16.gguf";
            InitilizeModel();
        }

        private  void InitilizeModel()
        {
            if (!File.Exists(ModelPath))
            {
                MessageBox.Show("Model not found");
                return;
            }

            var parameters = new ModelParams(ModelPath)
            {
                ContextSize = 1024, // The longest length of chat as memory.
                GpuLayerCount = 2 // How many layers to offload to GPU. Please adjust it according to your GPU memory.
            };

            var model = LLamaWeights.LoadFromFile(parameters);
            var context = model.CreateContext(parameters);
            var executor = new InteractiveExecutor(context);

            // Add chat histories as prompt to tell AI how to act.
            chatHistory = new ChatHistory();
            chatHistory.AddMessage(AuthorRole.System, "Transcript of a dialog, where the User interacts with an Assistant named Bob. Bob is helpful, kind, honest, good at writing, and never fails to answer the User's requests immediately and with precision.");
            chatHistory.AddMessage(AuthorRole.User, "Hello, Bob.");
            chatHistory.AddMessage(AuthorRole.Assistant, "Hello. How may I help you today?");

            chatSession = new ChatSession(executor, chatHistory);

            //inferenceParams = new InferenceParams()
            //{
            //    MaxTokens = 256, // No more than 256 tokens should appear in answer. Remove it if antiprompt is enough for control.
            //    AntiPrompts = new List<string> { "User:" } // Stop generation once antiprompts appear.
            //};

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.Write("The chat session has started.\nUser: ");
            //Console.ForegroundColor = ConsoleColor.Green;
            //string userInput = Console.ReadLine() ?? "";

            //while (userInput != "exit")
            //{
            //    await foreach ( // Generate the response streamingly.
            //        var text
            //        in session.ChatAsync(
            //            new ChatHistory.Message(AuthorRole.User, userInput),
            //            inferenceParams))
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;
            //        Console.Write(text);
            //    }
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    userInput = Console.ReadLine() ?? "";
            //}
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var userInput = userQueryTxtBox.Text;

                if (string.IsNullOrEmpty(userInput))
                {
                    MessageBox.Show("Please enter query");
                    return;
                }

                aiResponseTxtBox.Text = "";

                var inferenceParams = new InferenceParams()
                {
                    MaxTokens = 256, // No more than 256 tokens should appear in answer. Remove it if antiprompt is enough for control.
                    AntiPrompts = new List<string> { "User:" } // Stop generation once antiprompts appear.
                };
                var chats = chatSession.ChatAsync(new ChatHistory.Message(AuthorRole.User, userInput), inferenceParams);
                await foreach (var chat in chats)
                {
                    aiResponseTxtBox.Text += chat;
                }
                userQueryTxtBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while chat = " + ex.Message);
            }
        }
    }
}
