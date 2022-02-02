import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AccountService, AlertService } from '@app/_services';
import { error } from '@angular/compiler/src/util';

@Component({ templateUrl: 'register.component.html' })
export class RegisterComponent implements OnInit {
    form: FormGroup;
    loading = false;
    submitted = false;
    res: any;
    resu: any;
    response: any;

    public Step1 : boolean = true;
    public Step2 : boolean = false;
    public Step3 : boolean = false;
    public header : string = '';
    public message: string = '';

    public stateoforigin : AbstractControl;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private accountService: AccountService,
        private alertService: AlertService
    ) { }

    ngOnInit() {
        this.form = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            phoneNumber: ['', Validators.required],
            email: ['', Validators.compose([Validators.required, Validators.email])],
            state: ['', Validators.required],
            lga: ['', Validators.required],
            age: ['', Validators.required],
            businessName: [''],
            businessRegNumber: [''],
            directors: [''],
            businessEmail: ['', Validators.email],
            signature: ['', Validators.required],
            picture: ['', Validators.required],
        });

        this.accountService.State().subscribe((res)=>{
            this.res = res;
        })

        this.SwitchBackStep1();
    }

    ageChecker()
    {
        let newAge = parseInt(this.form.value.age);

        if(newAge < 18)
        {
            alert('Age must be greater than 18');
            this.form.get('age').reset();
        }
        {
            
        }
    }

    SwitchBackStep1()
    {
        this.Step1 = true;
        this.Step2 = false;
        this.Step3 = false;

        this.header = 'Personal Information';
    }

    SwitchBackStep2()
    {
        this.SwitchStep2();
    }

    SwitchStep2()
    {
        this.Step1 = false;
        this.Step2 = true;
        this.Step3 = false;

        this.header = 'Business Details';
    }

    SwitchStep3()
    {
        this.Step1 = false;
        this.Step2 = false;
        this.Step3 = true;

        this.header = 'Personal Documentation ';
    }

    GetLGA()
    {
        this.accountService.LGA(this.form.value.state).subscribe((result)=>{
            this.resu = result;
            console.log(this.resu)
        })
    }

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            this.message = 'One or more required field(s) is invalid';
            return;
        }

        this.loading = true;
        this.message = '';

        //convert the below value to string
        this.form.value.lga = this.form.value.lga.toString();
        this.form.value.phoneNumber = this.form.value.phoneNumber.toString();
        this.form.value.age = this.form.value.age.toString();

        this.accountService.register(this.form.value)
            .subscribe((res)=>{

                this.response = res;
                if(this.response.responseCode === 0)
                {
                    this.alertService.success( this.response.responseMessage, { keepAfterRouteChange: true });
                    this.router.navigate(['../Home'], { relativeTo: this.route });
                }
                else
                {
                    this.alertService.error(this.response.responseMessage);
                    this.loading = false;
                }
            }, error =>{
                this.alertService.error(error);
                    this.loading = false;
            });
    }
}