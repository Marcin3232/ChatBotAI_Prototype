import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { ChatMessage } from 'src/app/core/models/chat-message.model';
import { ChatResponse } from 'src/app/core/models/chat-response.model';
import { UpdateChatResponse } from 'src/app/core/models/update-chat-response.model';
import { ChatService } from 'src/app/core/services/chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit {
  @ViewChild('messageContainer') messageContainer!: ElementRef;

  chatMessages: ChatMessage[] = [];
  newMessage = '';
  userId = 1;
  currentMessage: ChatMessage | null = null;
  typingInterval: any;

  constructor(private chatService: ChatService) {}

  ngOnInit() {
    this.loadChatHistory();
  }

  loadChatHistory() {
    this.chatService.getMessagesByUser(this.userId).subscribe((messages) => {
      this.chatMessages = messages;
      this.scrollToBottom();
    });
  }

  async sendMessage() {
    if (!this.newMessage.trim()) return;

    const message = { userId: this.userId, userMessage: this.newMessage };
    const tempMessage = this.getTempMessage();

    this.chatMessages.push(tempMessage);
    this.newMessage = '';
    this.currentMessage = tempMessage;

    this.scrollToBottom();

    const response = await firstValueFrom(this.chatService.createMessage(message));
    Object.assign(this.currentMessage, response);

    if (response.responses.length > 0) {
      this.simulateTyping(response.responses[0]);
    }
  }

  simulateTyping(chatResponse: ChatResponse) {
    const text = chatResponse.botResponse || '';
    let currentIndex = 0;

    chatResponse.botResponse = '';

    this.typingInterval = setInterval(() => {
      if (currentIndex < text.length) {
        chatResponse.botResponse += text[currentIndex];
        currentIndex++;

        this.chatMessages = [...this.chatMessages];
        this.scrollToBottom();
      } else {
        this.stopTyping();
      }
    }, 100);
  }

  stopTyping() {
    if (this.typingInterval) {
      clearInterval(this.typingInterval);
      this.typingInterval = null;
    }

    if (this.currentMessage) {
      const botResponse = this.currentMessage.responses[0];
      const updateData: UpdateChatResponse = {
        id: botResponse.id,
        messageId: this.currentMessage.id,
        botResponse: botResponse.botResponse,
      };

      this.chatService.updateResponse(updateData).subscribe({
        next: () => console.log('Response updated successfully'),
        error: (err) => console.error('Error updating response:', err),
      });

      this.currentMessage = null;
    }
  }

  rateResponse(response: ChatResponse, rating: number | null) {
    const update = { id: response.id, rating };
    this.chatService.updateRating(update).subscribe((updatedResponse) => {
      response.rating = updatedResponse;
    });
  }

  scrollToBottom() {
    setTimeout(() => {
      if (this.messageContainer) {
        this.messageContainer.nativeElement.scrollTop =
          this.messageContainer.nativeElement.scrollHeight;
      }
    }, 0);
  }


  getTempMessage():ChatMessage{
    return {
      id: 0,
      userId: this.userId,
      user: { id: this.userId, name: 'Default' },
      userMessage: this.newMessage,
      created: new Date().toISOString(),
      responses: [
        {
          id: 0,
          messageId: 0,
          botResponse: '',
          rating: null,
          created: new Date().toISOString(),
          message: null,
        },
      ],
    };
  }
}
