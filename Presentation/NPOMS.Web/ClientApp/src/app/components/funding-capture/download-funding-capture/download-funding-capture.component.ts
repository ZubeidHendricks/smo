import { Component, OnInit } from '@angular/core';
import { IBankDetailViewModel, IDocumentViewModel, IFundingCaptureViewModel, IFundingDetailViewModel, INpoViewModel, IPaymentScheduleViewModel, ISDAViewModel } from 'src/app/models/interfaces';
import * as html2pdf from 'html2pdf.js';

@Component({
  selector: 'app-download-funding-capture',
  templateUrl: './download-funding-capture.component.html',
  styleUrls: ['./download-funding-capture.component.css']
})
export class DownloadFundingCaptureComponent implements OnInit {

  _showViewer: boolean;
  _emptyArray: any[] = [{}];

  npo: INpoViewModel;
  fundingCapture: IFundingCaptureViewModel;
  fundingDetail: IFundingDetailViewModel;
  sda: ISDAViewModel;
  paymentSchedule: IPaymentScheduleViewModel;
  bankDetail: IBankDetailViewModel;
  document: IDocumentViewModel;

  constructor() { }

  ngOnInit(): void {
  }

  public generatePDF(fundingPDF: INpoViewModel) {
    this.npo = fundingPDF;
    this.fundingCapture = fundingPDF.fundingCaptureViewModels[0];
    this.fundingDetail = this.fundingCapture.fundingDetailViewModel;
    this.sda = this.fundingCapture.sdaViewModel;
    this.paymentSchedule = this.fundingCapture.paymentScheduleViewModel;
    this.bankDetail = this.fundingCapture.bankDetailViewModel;
    this.document = this.fundingCapture.documentViewModel;

    this._showViewer = true;

    // Wait for Angular to render the hidden div
    setTimeout(() => {
      // Get the HTML element for the content you want to convert to PDF
      const element = document.getElementById('pdfContent');
      const opt = {
        margin: 1,
        pagebreak: { mode: ['avoid-all', 'css'], after: '#firstPage', before: '#nextPage' },
        filename: `Funding for ${this.npo.name} (${this.fundingDetail.financialYearName}) - ${this.fundingDetail.programmeName} - ${this.fundingDetail.subProgrammeTypeName} - R${this.fundingDetail.amountAwarded}.pdf` // specify the file name here
      };

      // Call html2pdf to generate the PDF
      html2pdf().set(opt).from(element).save();

      // Reset generatePDF to false to hide the div again
      this._showViewer = false;
    }, 0);
  }

  get headerText() {
    return 'NPO Management System';
  }
}
