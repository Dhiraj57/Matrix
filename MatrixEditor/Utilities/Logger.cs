﻿using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace MatrixEditor.Utilities
{
    public enum MessageType
    {
        Info = 0x01,
        Warning = 0x02,
        Error = 0x04,
    }

    public class LogMessage
    {
        public DateTime Time { get; }
        public MessageType MessageType { get; }
        public string Message { get; }
        public string File { get; }
        public string Caller { get; }
        public int Line { get; }

        public string MetaData => $"{File}: {Caller} ({Line})";

        public LogMessage(MessageType messageType, string message, string file, string caller, int line)
        {
            Time = DateTime.Now;
            MessageType = messageType;
            Message = message;
            File = file;
            Caller = caller;
            Line = line;
        }
    }

    public static class Logger
    {
        private static int _messageFilter = (int)(MessageType.Info | MessageType.Warning | MessageType.Error);

        private static ObservableCollection<LogMessage> _messages = new ObservableCollection<LogMessage>();
        public static ReadOnlyObservableCollection<LogMessage> Messages = new ReadOnlyObservableCollection<LogMessage>(_messages);

        public static CollectionViewSource FilteredMessages { get; } = new CollectionViewSource() { Source = Messages};

        public static async void Log(MessageType messageType, string message, 
            [CallerFilePath] string file = "", [CallerMemberName] string caller = "", 
            [CallerLineNumber] int line = 0)
        {
            await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            { 
                _messages.Add(new LogMessage(messageType, message, file, caller, line)); 
            }));
        }

        public static async void Clear()
        {
            await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                _messages.Clear();
            }));
        }

        public static void SetMessageFilter(int mask)
        {
            _messageFilter = mask;
            FilteredMessages.View.Refresh();
        }

        static Logger()
        {
            FilteredMessages.Filter += (s, e) =>
            {
                var type = (int)(e.Item as LogMessage).MessageType;
                e.Accepted = (_messageFilter & type) != 0;
            };
        }
    }
}
