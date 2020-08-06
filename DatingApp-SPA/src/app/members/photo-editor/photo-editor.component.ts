import { Component, OnInit, Input } from '@angular/core';
import { photo } from '../../_models/photo';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css']
})
export class PhotoEditorComponent implements OnInit {
@Input() photos: photo[];
  constructor() { }

  ngOnInit() {
  }

}
