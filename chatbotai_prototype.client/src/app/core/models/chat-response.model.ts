import { ChatMessage } from "./chat-message.model";

export interface ChatResponse {
  id: number;
  messageId: number;
  botResponse: string;
  rating: number | null;
  created: string;
  message: ChatMessage | null;
}
