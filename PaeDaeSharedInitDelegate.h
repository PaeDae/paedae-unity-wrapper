//
//  PaeDaeSharedInitDelegate.h
//
//  Created by Miguel Morales on 7/19/12.
//  Copyright (c) 2012 PaeDae Inc. All rights reserved.

#import <Foundation/Foundation.h>
#import "PaeDaePrizeSDK.h"

@interface PaeDaeSharedInitDelegate : NSObject<PaeDaeInitDelegate>
+ (PaeDaeSharedInitDelegate *) sharedDelegate;

- (void)PaeDae_Initialized;
- (void)PaeDae_InitializeFailed;
@end
