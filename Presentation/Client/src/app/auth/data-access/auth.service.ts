import { Injectable } from '@angular/core';
import {
  Auth,
  createUserWithEmailAndPassword,
  GoogleAuthProvider,
  sendEmailVerification,
  sendPasswordResetEmail,
  signInWithEmailAndPassword,
  signInWithPopup,
  signOut,
  updateProfile,
  User,
} from '@angular/fire/auth';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpService } from '../../shared/data-access/http.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(
    private auth: Auth,
    private http: HttpService,
    private toastr: ToastrService,
    private router: Router,
  ) {}

  async login(email: string, password: string): Promise<void> {
    try {
      const userCredential = await signInWithEmailAndPassword(
        this.auth,
        email,
        password,
      );

      if (userCredential.user) {
        const user = userCredential.user;
        await this.saveUserInfo(user);
        await this.navigateToWishlists();
      }
    } catch (error: any) {
      console.error(error);
      switch (error.code) {
        case 'auth/invalid-credential':
          this.toastr.error('Provided credentials are not valid', 'Error');
          break;
      }
    }
  }

  async register(name: string, email: string, password: string): Promise<void> {
    try {
      const userCredential = await createUserWithEmailAndPassword(
        this.auth,
        email,
        password,
      );

      if (userCredential.user) {
        const user = userCredential.user;
        await this.saveUserInfo(user);
        await updateProfile(user, { displayName: name });
        await sendEmailVerification(user);
        await this.createUser(name, email, user.uid);
        await this.navigateToWishlists();
      }
    } catch (error: any) {
      console.error(error);
      switch (error.code) {
        case 'auth/email-already-in-use':
          this.toastr.error('Email is already in use', 'Error');
          break;
      }
    }
  }

  async loginWithGoogle() {
    try {
      const provider = new GoogleAuthProvider();
      const userCredential = await signInWithPopup(this.auth, provider);

      if (userCredential.user) {
        const user = userCredential.user;
        await this.saveUserInfo(user);
        const registrationDate = new Date(user.metadata.creationTime!);

        // Check whether the user was registered just now (3 sec difference)
        if (registrationDate.getTime() - new Date().getTime() > -3000) {
          await this.createUser(user.displayName!, user.email!, user.uid);
        }

        // Google automatically verifies gmail.com domains and the business google domain only
        if (!user.emailVerified) {
          await sendEmailVerification(user);
        }

        await this.navigateToWishlists();
      }
    } catch (error) {
      console.error(error);
      this.toastr.error('Error', 'Something went wrong');
    }
  }

  async sendPasswordResetEmail(email: string): Promise<void> {
    try {
      await sendPasswordResetEmail(this.auth, email);
      return Promise.resolve();
    } catch (error: any) {
      switch (error.code) {
        case 'auth/invalid-email':
          this.toastr.error('Provided email is not valid', 'Error');
          break;
      }
      return Promise.reject(error);
    }
  }

  async logout() {
    await signOut(this.auth);
    this.clearUserInfo();
    await this.router.navigate(['/auth/login']);
  }

  async getCurrentUserEmail() {
    return this.auth.currentUser!.email!;
  }

  private async createUser(name: string, email: string, firebaseUid: string) {
    await this.http
      .post('/users', { name: name, email: email, firebaseUid: firebaseUid })
      .toPromise();
  }

  private async saveUserInfo(user: User) {
    const token = await user.getIdToken();
    localStorage.setItem('token', token);
    localStorage.setItem('displayName', user.displayName!);
    localStorage.setItem('photoUrl', user.photoURL!);
  }

  private clearUserInfo() {
    localStorage.removeItem('token');
    localStorage.removeItem('displayName');
    localStorage.removeItem('photoUrl');
  }

  private async navigateToWishlists() {
    await this.router.navigate(['/wishlists/library']);
  }
}
