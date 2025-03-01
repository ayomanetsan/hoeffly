export interface FriendResponse {
  id: string;
  name: string;
  email: string;
  status: InvitationStatus;
}

export enum InvitationStatus {
  Pending = 0,
  Accepted = 1,
  Rejected = 2,
}

export interface SendFriendshipRequest {
  email: string;
}

export interface ManageFriendshipRequest {
  id: string;
  status: InvitationStatus;
}
