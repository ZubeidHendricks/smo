import { Component, Input, OnInit } from '@angular/core';
import { IDocumentViewModel } from 'src/app/models/interfaces';
import { FundingManagementService } from 'src/app/services/api-services/funding-management/funding-management.service';

@Component({
  selector: 'app-fc-document',
  templateUrl: './fc-document.component.html',
  styleUrls: ['./fc-document.component.css']
})
export class FCDocumentComponent implements OnInit {

  @Input() toggleable: boolean;
  @Input() document: IDocumentViewModel;
  @Input() isEdit: boolean;

  private _validated: boolean;
  @Input()
  get validated(): boolean { return this._validated; }
  set validated(validated: boolean) { this._validated = validated; }

  constructor(
    private _fundingManagementRepo: FundingManagementService
  ) { }

  ngOnInit(): void {
  }

  public valueChanged() {
    this.document.tpaLink = this.document.tpaLink ? this.document.tpaLink : null;
    this._fundingManagementRepo.updateDocument(this.document).subscribe();
  }
}
