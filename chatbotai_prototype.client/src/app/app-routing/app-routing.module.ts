import { NgModule } from '@angular/core';
import { ChatComponent } from '../pages/chat/chat.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: ChatComponent },
  { path: '**', redirectTo: '' }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
