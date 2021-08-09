using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot
{
    class Program
    {
        private static string token = "1904804750:AAG2D8UImD2mFwGSrFKfyO5sLenAy3ihpu8";

        private static TelegramBotClient client;


        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;

            if (msg.Text != null) 

            {

                Console.WriteLine($" пришло сообщение с текстом: {msg.Text} ");

                //await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId); Принимает текст и отвечает тем-же
                // var stic = await client.SendStickerAsync(chatId: msg.Chat.Id, sticker: "paste Linck",replyToMessageId: msg.MessageId) ;
                //Возвращает стикеры по ссылке
                // await client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyMarkup: GetButtons()); Возвращает текст на кнопке 

                switch (msg.Text)
                {
                    case "Стикер":
                        var stic = await client.SendStickerAsync(
                          chatId: msg.Chat.Id,
                            sticker: "https://tlgrm.ru/_/stickers/8c0/427/8c042720-c3bc-4b75-997e-25b666d88da4/4.webp",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons());
                        break;

                    case "Картинка":
                        var pic = await client.SendPhotoAsync(
                            chatId: msg.Chat.Id,
                            photo: "https://www.google.com.ua/imgres?imgurl=https%3A%2F%2Fi.ytimg.com%2Fvi%2Fo4PtPwKfdY8%2Fmaxresdefault.jpg&imgrefurl=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3Do4PtPwKfdY8&tbnid=QP9X83gBjVLjXM&vet=12ahUKEwiIvNrUx6LyAhXUk6QKHVmxDF8QMygEegUIARDVAQ..i&docid=djRw2hE4QsRUEM&w=1280&h=720&q=%D0%B4%D1%80%D0%B0%D0%BA%D0%BE%D0%BD%D1%8B&hl=ru&ved=2ahUKEwiIvNrUx6LyAhXUk6QKHVmxDF8QMygEegUIARDVAQ",
                            replyMarkup: GetButtons());
                        break;

                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, " выберете команду: ", replyMarkup: GetButtons());
                        break;



                }
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> {new KeyboardButton { Text = "Стикер"}, new KeyboardButton { Text = "Картинка"} },// Один список - один ряд кнопок

                    new List<KeyboardButton> {new KeyboardButton { Text = " 123 "}, new KeyboardButton { Text = " 456 "} }
                }
            };
        }
    }
}
