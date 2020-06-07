import { Component, OnInit } from '@angular/core';
import { Message } from 'primeng/api';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss'],
})
export class MessageComponent implements OnInit {
  msgs: Message[];

  constructor(private messageService: MessageService) {}

  ngOnInit(): void {}

  showMessage(): Message[] {
    this.messageService.messageObserver.subscribe((msg: Message) => {
      this.msgs = [];
      this.msgs.unshift(msg);
    });

    return this.msgs;
  }
}
