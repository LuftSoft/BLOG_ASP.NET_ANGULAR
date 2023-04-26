import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css']
})
export class PaginationComponent implements OnInit {
  @Output() paging: EventEmitter<any> = new EventEmitter();
  @Input() page_total?: number;
  @Input() name: string;
  arrayPage: number[];
  currentPage = 1;
  constructor() {

  }

  ngOnInit(): void {
  }

  pageChange(i: any) {
    this.paging.emit(i);
  }

}
