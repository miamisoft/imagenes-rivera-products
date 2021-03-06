import { Component, OnInit, Input, Output, EventEmitter, ViewEncapsulation, ViewChildren, QueryList, OnChanges, SimpleChanges } from '@angular/core';
import { PageCropperComponent } from './page-cropper/page-cropper.component';
import Cropper from 'cropperjs';
import { Observable } from 'rxjs';

export interface ISlideModel {
  index: number;
  photo: File;
  layout: number;
  visible: boolean;
}

export interface ICroppedCanvas {
  index: number;
  blob: Blob;
}

@Component({
  selector: 'app-book-pagescarousel',
  templateUrl: './pages-carousel.component.html',
  styleUrls: ['./pages-carousel.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class PagesCarouselComponent implements OnInit {

  @ViewChildren(PageCropperComponent)
  pageCroppers: QueryList<PageCropperComponent>;

  @Output()
  public pageChangedEvent = new EventEmitter();

  public slides: ISlideModel[];
  public slideSelected: ISlideModel;
  public cropperComponentSelected: PageCropperComponent;
  public cropperSelected: Cropper;
  public layoutSelected: number;
  public navIndex: number;

  constructor() { }

  ngOnInit() {
    this.layoutSelected = 2; 
    this.navIndex = 1;
  }

  public cropPageCanvas(): Observable<ICroppedCanvas> {
    return new Observable(observer => {
      this.slides.forEach((slide: ISlideModel) => {
        const component = this.pageCroppers.find((item) => item.slideIndex === slide.index);
        if (component && component.cropper) {
            const cropper = component.cropper as Cropper;
            const canvas = cropper.getCroppedCanvas({ 
              fillColor: 'white', 
              width: component.layout === 1 ? 591 * 2 : 591, 
              height: 591 
            });
            
            canvas.toBlob((blob: Blob) => {
              observer.next({ index: slide.index, blob });
              if (slide.index === this.slides.length) {
                observer.complete();
              }
            }, 'image/jpeg', '1');
        }
      });
    });
  }

  public get nextBtnDisabled(): boolean {
     return this.slides && (this.navIndex + this.layoutSelected) >= this.slides.length;
  }

  public get prevBtnDisabled(): boolean {
    return this.slides && (this.navIndex - this.layoutSelected) <= 0;
  }

  public initSlides(pagesNumber: number, image: File): void {
    this.slides = [];
    for (let index = 1; index <= pagesNumber; index++) {
      this.slides.push({ index, photo: null, layout: this.layoutSelected, visible: false });
    }
    this.slides[0].photo = image;
    this.selectSlide(this.slides[0]);   
  }

  public addImageToCurrentSlide(image: File) {
    this.slideSelected.photo = image;
  } 

 
  selectSlide(slide: ISlideModel) {
    this.slides.forEach(s => s.visible = false);
    this.slideSelected = slide;
    this.slideSelected.visible = true;
    this.slideSelected.layout = this.layoutSelected;
    const position = this.slideSelected.index - 1;
    // Two Slides Layout
    if(this.layoutSelected === 2) {
      if(this.slideSelected.index % 2 !== 0) { 
        // Odd on Left
        this.slides[position + 1].visible = true;
      } else { 
        // Even on Right
        this.slides[position - 1].visible = true;
      }
    }

    if(this.slideSelected.photo) {
      this.cropperComponentSelected = this.pageCroppers.find((item) => item.slideIndex === this.slideSelected.index);
      this.cropperSelected = this.cropperComponentSelected ? this.cropperComponentSelected.cropper : null;
    }
  }

  pageLayoutChangeHandled(layout: number) {
    this.layoutSelected = layout;
    this.slideSelected.layout = layout;
    this.selectSlide(this.slideSelected);
  }

  slideRangeChangeHandled(index: number) {
    this.pageChangedEvent.emit(index);
  }

  undoClick() {
   this.cropperSelected.reset();
  }

  zoomInClick() {
    this.cropperSelected.zoom(0.1);
  }

  zoomOutClick() {
    this.cropperSelected.zoom(-0.1);
  }

  moveLeftClick() {
    this.cropperSelected.move(-10,0);
  }

  moveRightClick() {
    this.cropperSelected.move(10,0);
  }

  moveUpClick() {
    this.cropperSelected.move(0,-10);
  }

  moveDownClick() {
    this.cropperSelected.move(0,10);
  }

  rotateLeftClick() {
    this.cropperSelected.rotate(-45);
  }

  rotateRightClick() {
    this.cropperSelected.rotate(45);
  }

  removeClick() {
    if(confirm('Are you sure?')) {
      this.slideSelected.photo = null;
    }
  }

  prevSlideClick() {
    this.navIndex= this.navIndex - this.layoutSelected;  
    const position = this.slideSelected.index - 1;
    if(position >= this.layoutSelected) {
      this.selectSlide(this.slides[position - this.layoutSelected]);
    }
  }

  nextSlideClick() {  
    this.navIndex= this.navIndex + this.layoutSelected;  
    const position = this.slideSelected.index - 1;
    if(position < this.slides.length - this.layoutSelected) {
      this.selectSlide(this.slides[position + this.layoutSelected]);
    }
  }
}
