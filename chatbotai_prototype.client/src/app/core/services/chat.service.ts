import { Observable } from 'rxjs';
import { UpdateRatingChatResponse } from '../models/update-rating-chat-response.model';
import { ChatMessage } from '../models/chat-message.model';
import { UpdateChatResponse } from '../models/update-chat-response.model';
import { CreateChatMessage } from '../models/create-chat-message.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  private readonly apiUrl = 'https://localhost:7022/ChatAI';

  constructor(private http: HttpClient) {}

  getMessagesByUser(userId: number): Observable<ChatMessage[]> {
    return this.http.get<ChatMessage[]>(`${this.apiUrl}?userId=${userId}`);
  }

  createMessage(message: CreateChatMessage): Observable<ChatMessage> {
    return this.http.post<ChatMessage>(`${this.apiUrl}/createMessage`, message);
  }

  updateResponse(response: UpdateChatResponse): Observable<ChatMessage> {
    return this.http.put<ChatMessage>(`${this.apiUrl}/updateRespone`, response);
  }

  updateRating(response: UpdateRatingChatResponse): Observable<number | null> {
    return this.http.put<number | null>(
      `${this.apiUrl}/updateRatingResponse`,
      response
    );
  }
}
