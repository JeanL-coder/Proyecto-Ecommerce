import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductoService } from '../../../services/producto.service';
import { ToastrService } from 'ngx-toastr';
import ValidateForm from '../../../helpers/validateForms';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  public productoForm!: FormGroup;
  public selectedImage: File | null = null; 

  constructor(
    private formBuilder: FormBuilder,
    private productoService: ProductoService,
    private toastrService: ToastrService
  ) { }
 
  ngOnInit(): void {
    this.productoForm = this.formBuilder.group({
      Nombre: ['', Validators.required],
      Descripcion: ['', Validators.required],
      Precio: ['', [Validators.required, Validators.min(0)]],
      Stock: ['', [Validators.required, Validators.min(0)]],
      CategoriaID: ['', [Validators.required, Validators.min(1)]],
      ProveedorID: ['', [Validators.required, Validators.min(1)]],
      Imagen: [null] 
    });
  }

  agregarProducto() {
    if (this.productoForm.valid) {
      const productoData = this.productoForm.value;
      if (this.selectedImage) {
        productoData.Imagen = this.selectedImage; 
      } else {
        console.error('No se ha seleccionado ninguna imagen.');
        return; 
      }
  
      this.productoService.agregarProducto(productoData).subscribe({
        next: (response: any) => {
          console.log('Producto agregado exitosamente:', response);
        },
        error: (error: any) => {
          console.error('Error al agregar producto:', error);
        }
      });
    } else {
      console.error('El formulario no es válido.');
    }

    }
    onImageSelected(event: any) {
  this.selectedImage = event.target.files[0];
}
}

  
  

