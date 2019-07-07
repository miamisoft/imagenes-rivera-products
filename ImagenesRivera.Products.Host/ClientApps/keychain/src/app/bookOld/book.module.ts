import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { BookComponent } from './book.component';
import { SharedModule } from '../shared/shared.module';
import { ImageCropperModule } from 'ngx-image-cropper';
import { NgxCropperJsModule } from 'ngx-cropperjs-wrapper';


@NgModule({
  declarations: [BookComponent],
  exports: [BookComponent],
  imports: [
    SharedModule,
    RouterModule,
    ImageCropperModule,
    NgxCropperJsModule
  ]
})
export class BookModule { }
