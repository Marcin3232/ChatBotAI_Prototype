import { ChatResponse } from "./chat-response.model";
import { User } from "./user.model";

export interface ChatMessage {
  id: number;
  userId: number;
  user: User;
  userMessage: string;
  created: string;
  responses: ChatResponse[];
}
